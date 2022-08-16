using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository;
using ContactDirectoriesLoader.Repository.Base;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Services
{
    /// <summary>
    /// Сервис обновления справочников банка
    /// </summary>
    public class UpdatingService : IUpdatingService
    {
        private readonly IServiceProvider _services;

        //Настройка - загружается ли полный справочник? 
        private bool _loadFullDirectory = true;

        /// <summary>
        /// .ctor
        /// </summary>
        public UpdatingService(IServiceProvider services)
        {
            _services = services;
        }

        /// <summary>
        /// Обновить справочник.
        /// </summary>
        /// <param name="directory">Справочник</param>
        /// <param name="directoryVersion">Версия загружаемого справочника</param>
        public async Task UpdateDirectory<TDirectory, TRepository>(List<TDirectory> directory, int? directoryVersion = null)
            where TDirectory : class, IDirectory
            where TRepository : BaseRepository<TDirectory>
        {
            GetSettings();

            if (_loadFullDirectory)
            {
                using (var scope = _services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<IDbContext>();

                    var repo = Activator.CreateInstance(typeof(TRepository), new object[] { dbContext }) as TRepository;

                    //Загружаем новый справочник быстрым способом (массовая загрузка).
                    await repo.AddBatchAsync(directory);
                }
            }
            else 
            {
                //Проверяем и обновляем каждую запись.
                directory.ForEach(async record =>
                                    {
                                        using (var scope = _services.CreateScope())
                                        {
                                            var dbContext = scope.ServiceProvider.GetRequiredService<IDbContext>();

                                            var repo = Activator.CreateInstance(typeof(TRepository), new object[] { dbContext }) as TRepository;

                                            if (record.Erased)
                                            {
                                                await repo.DeleteAsync(record);
                                            }
                                            else
                                            {
                                                await repo.SaveAsync(record, true);
                                            }
                                        }
                                    });
            }
        }

        /// <summary>
        /// Извлечь версию справочника и сохранить её в базе
        /// </summary>
        /// <param name="response">Ответ Contact бизнес-уровня.</param>
        /// <param name="directoryVersion">Загружаемая версия справочника.</param>
        /// <param name="startDateTime">Дата и время первого запроса.</param>
        public async Task SaveLoadingInfo(ContactBusinessLevelResponse response, int directoryVersion, DateTime? startDateTime = null)
        {
            using (var scope = _services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IDbContext>();

                var loadingInfoRepo = new LoadingInfoRepository(dbContext);

                var loadingInfo = new LoadingInfo()
                {
                    Version = directoryVersion,
                    ResponseIsFull = response.Full,
                    StartDateTime = startDateTime ?? DateTime.Now,
                    EndDateTime = DateTime.Now,

                };

                await loadingInfoRepo.SaveAsync(loadingInfo, true);
            }    
        }

        /// <summary>
        /// Получить контекст БД
        /// </summary>
        private IDbContext GetDbContext()
        {
            using (var scope = _services.CreateScope())
            {
                return scope.ServiceProvider.GetRequiredService<IDbContext>();
            }
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

            _loadFullDirectory = Convert.ToBoolean(configuration["LoadFullDirectory"]);
        }

    }
}
