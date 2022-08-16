using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Services
{
    /// <inheritdoc/>
    public class DirectoryLoadingService : IDirectoryLoadingService
    {
        private readonly ILogger<DirectoryLoadingService> _logger;
        private readonly IDownloadingService _downloadingService;
        private readonly IProcessingService _processingService;
        private readonly IServiceProvider _services;

        //Загрузка по частям - поле заполняется из настроек.
        private bool _needLoadByParts = false;

        //Загрузка полного справочника - поле заполняется из настроек.

        private bool _needLoadFullDirectory = false;

        public DirectoryLoadingService(ILogger<DirectoryLoadingService> logger,
                                       IDownloadingService downloadingService,
                                       IProcessingService processingService,
                                       IServiceProvider services)
        {
            _logger = logger;
            _downloadingService = downloadingService;
            _processingService = processingService;
            _services = services;
        }

        /// <summary>
        /// Загрузка параметров из настроек.
        /// </summary>
        private void GetSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            if (configuration == null)
            {
                throw new ApplicationException($"{ nameof(configuration)} is null!");
            }

            _needLoadByParts = Convert.ToBoolean(configuration["LoadByParts"]);
            _needLoadFullDirectory = Convert.ToBoolean(configuration["LoadFullDirectory"]);
        }

        /// <inheritdoc/>
        public async Task Load()
        {
            try
            {
                GetSettings();

                if (_needLoadFullDirectory)
                {
                    _logger.LogInformation("Загружается полные справочники");
                    
                    ClearDirectories();
                }
                {
                    _logger.LogInformation("Загружаются обновления справочников");
                }


                if (_needLoadByParts)
                {
                    _logger.LogInformation("Загрузка справочников по частям...");

                    await LoadDirectoryByParts();

                    _logger.LogInformation("Загрузка справочников по частям завершена.");
                }
                else
                {
                    _logger.LogInformation("Загрузка справочников целиком (не по частям)...");

                    await LoadFullDirectory();

                    _logger.LogInformation("Загрузка справочников (целиком) завершена.");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }

        /// <summary>
        /// Очистить справочники в базе.
        /// </summary>
        private void ClearDirectories()
        {
            _logger.LogInformation("Очистка справочников...");
            try
            {
                using (var scope = _services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<IDbContext>();

                    dbContext.GetDatabase().ExecuteSqlRaw("exec [dbo].[ClearContactDirectories]");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
            _logger.LogInformation("Очистка справочников завершена.");
        }
            
        /// <summary>
        /// Загрузить справочник по частям
        /// </summary>
        private async Task LoadDirectoryByParts()
        {
            //Всего попыток (в случае исключеняи и т.д.).
            const int MaxTryCount = 3;
            //Время ожидания между попытками. 
            const int TrySleepMilliseconds = 10000;

            //Всего частей. 
            int totalDirectoryParts = 0;
            //Текущая загружаемая часть. 
            int currentDirectoryPart = 0;
            //Идентификатор справочника, разбиваемого на части.
            string partitionDirectoryId = "";

            int directoryVersion = -1;

            #region Загрузка первой версии справочника.

            DateTime firstRequestDateTime = DateTime.Now;

            _logger.LogInformation($"Загружается: новый справочник, часть: 1");
            try
            {
                //Получение справочника.
                var directories = await _downloadingService.LoadDirectories(partitionDirectoryId, 0);

                if (totalDirectoryParts == 0)
                {
                    totalDirectoryParts = directories.TypedTotalPartsAmount ?? throw new ApplicationException("Ответ от Contact не содержит количество частей!");
                    partitionDirectoryId = directories.PartitionDirectoryId ?? throw new ApplicationException("Ответ от Contact не содержит идентификатор разбиваемого на части справочника!");
                }

                currentDirectoryPart = directories.TypedCurrentPartNumber ?? throw new ApplicationException("Ответ от Contact не содержит номер текущей части!");

                directoryVersion = directories.Version;

                _logger.LogInformation($"Версия нового справочника: {directoryVersion}");

                //Обработка справочника.
                await _processingService.Process(directories, directoryVersion, currentDirectoryPart, totalDirectoryParts, firstRequestDateTime);

            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "Ошибка загрузка справочника по частям. Справочник: 1, Часть: {CurrentDirectoryPart} из {TotalDirectoryParts}, Ошибка: {MessageText}", currentDirectoryPart, totalDirectoryParts, exc.Message);

                throw;
            }
            #endregion

            #region Загрузка остальных частей справочника
            if (totalDirectoryParts > 1)
            { 
                //По всем частям.
                for (int currentPart = 2; currentPart <= totalDirectoryParts; currentPart++)
                {
                    //По всем попыткам (в случае исключения и т.д.).
                    for (int tryCount = 1; tryCount <= MaxTryCount; tryCount++)
                    {
                        _logger.LogInformation($"Загружается: Справочник: {partitionDirectoryId}, Часть: {currentPart} из {totalDirectoryParts}");
                        try 
                        {
                            //Получение справочника.
                            var directories = await _downloadingService.LoadDirectories(partitionDirectoryId, currentPart);

                            currentDirectoryPart = directories.TypedCurrentPartNumber ?? throw new ApplicationException("Ответ от Contact не содержит номер текущей части!");

                            //Обработка справочника.
                            await _processingService.Process(directories, directoryVersion, currentDirectoryPart, totalDirectoryParts, firstRequestDateTime);

                            break;
                        }
                        catch (Exception exc)
                        {
                            _logger.LogError(exc, "Ошибка загрузка справочника по частям. Справочник: {PartitionDirectoryId}, Часть: {CurrentDirectoryPart} из {TotalDirectoryParts}, Ошибка: {MessageText}", partitionDirectoryId, currentDirectoryPart, totalDirectoryParts, exc.Message);

                            if (tryCount == MaxTryCount)
                            {
                                throw;
                            }
                            else
                            {
                                //Ожидание следующей попытки.
                                Thread.Sleep(TrySleepMilliseconds);
                            }
                        }
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Загрузить полный справочник
        /// </summary>
        private async Task LoadFullDirectory()
        {
            DateTime firstRequestDateTime = DateTime.Now;

            var directories = await _downloadingService.LoadDirectories();

            await _processingService.Process(directories, firstRequestDateTime);

            //if (directories != null)
            //{
            //    File.WriteAllText(@"D:\Projects\DictionaryLoader\ContactDir_full_1.txt", directories, System.Text.Encoding.GetEncoding(1251));
            //}
        }
    }
}
