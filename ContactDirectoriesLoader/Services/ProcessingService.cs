using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Mappers;
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
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Services
{
    /// <summary>
    /// Сервис обработки полученного XML со справочником
    /// </summary>
    public class ProcessingService : IProcessingService
    {
        private readonly IUpdatingService _updatingService;
        private readonly ILogger<DirectoryLoadingService> _logger;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <returns></returns>
        public ProcessingService(IUpdatingService updatingService,
                                 ILogger<DirectoryLoadingService> logger)
        {
            _updatingService = updatingService;
            _logger = logger;
        }

        /// <summary>
        /// Разобрать входящий справочник CONTACT.
        /// </summary>
        /// <param name="contactDirectories">Справочники CONTACT.</param>
        /// <param name="firstRequestDateTime">Дата и время первого запроса.</param>
        /// <returns>XML-строка со справочником банков</returns>
        public async Task Process(ContactBusinessLevelResponse contactDirectories,
                                            DateTime? firstRequestDateTime = null)
        {
             await Process(contactDirectories, contactDirectories.Version, 0, 1, firstRequestDateTime);
        }

        /// <summary>
        /// Загрузить XML-справочник банков  
        /// </summary>
        /// <param name="contactDirectories">Справочники CONTACT.</param>
        /// <param name="directoryVersion">Версия справочника</param>
        /// <param name="currentDirectoryPart">Текущая загружаемая часть.</param>
        /// <param name="totalDirectoryParts">Всего частей.</param>
        /// <param name="firstRequestDateTime">Дата и время первого запроса.</param>
        /// <returns>XML-строка со справочником банков</returns>
        public async Task Process(ContactBusinessLevelResponse contactDirectories, 
                                                           int directoryVersion, 
                                                           int currentDirectoryPart, 
                                                           int totalDirectoryParts,
                                                           DateTime? firstRequestDateTime = null)
        {
            try
            {
                bool loadByParts = currentDirectoryPart > 0;

                if (loadByParts)
                {
                    _logger.LogInformation($"Обработка справочников: обрабатывается часть {currentDirectoryPart} из {totalDirectoryParts}");
                }
                else
                {
                    _logger.LogInformation("Обрабоотка справочников");
                }

                await ProcessDirectories(contactDirectories, directoryVersion);
                //Обновить версию справочника в базе

                if ((!loadByParts) || (currentDirectoryPart == totalDirectoryParts))
                {
                    if (firstRequestDateTime == null)
                    {
                        firstRequestDateTime = DateTime.Now;
                    }
                    _logger.LogInformation("Обновление версии справочников");
                    await _updatingService.SaveLoadingInfo(contactDirectories, directoryVersion, firstRequestDateTime);
                }
                _logger.LogInformation("Обрабоотка справочников завершена");

                if (loadByParts)
                {
                    _logger.LogInformation($"Обрабоотка справочников: обработана часть {currentDirectoryPart} из {totalDirectoryParts}");
                }
                else
                {
                    _logger.LogInformation("Обрабоотка справочников");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка обрабоотки справочников:{ex.Message}");  
            }
        }

        private async Task ProcessDirectories(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            await ProcessBadDocsirectory(contactDirectories, directoryVersion);
            await ProcessBanksDirectory(contactDirectories, directoryVersion);
            await ProcessBankCitiesDirectory(contactDirectories, directoryVersion);
            await ProcessBankServicesDirectory(contactDirectories, directoryVersion);
            await ProcessControlRulesDirectory(contactDirectories, directoryVersion);
            await ProcessControlRulesDirectory(contactDirectories, directoryVersion);
            await ProcessCountryDirectory(contactDirectories, directoryVersion);
            await ProcessFeatureTextDirectory(contactDirectories, directoryVersion);
            await ProcessFeaturesDirectory(contactDirectories, directoryVersion);
            await ProcessFinancialMonitoringInfoDirectory(contactDirectories, directoryVersion);
            await ProcessLimitsDirectory(contactDirectories, directoryVersion);
            await ProcessLogosDirectory(contactDirectories, directoryVersion);
            await ProcessMetroLinesDirectory(contactDirectories, directoryVersion);
            await ProcessMetroStationsDirectory(contactDirectories, directoryVersion);
            await ProcessRegionsDirectory(contactDirectories, directoryVersion);
            await ProcessScenarioItemDirectory(contactDirectories, directoryVersion);
            await ProcessServDirectory(contactDirectories, directoryVersion);
    }

    private async Task ProcessBadDocsirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
    {
      if (contactDirectories.BadDocsDirectory == null)
      {
        return;
      }

      _logger.LogInformation("Загрузка справочника плохих паспортов...");

      var compressedDirectory = contactDirectories.BadDocsDirectory;

       ProcessDirectory<BadDocModel, BadDoc, BadDocMapper, BadDocRepository>(compressedDirectory, directoryVersion);

      _logger.LogInformation("Загрузка справочника плохих паспортов завершена");
    }
    private async Task ProcessBanksDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
    {
      if (contactDirectories.BanksDirectory == null)
      {
        return;
      }

      _logger.LogInformation("Загрузка справочника банков...");

      var compressedDirectory = contactDirectories.BanksDirectory;

      await ProcessDirectory<BankModel, Bank, BankMapper, BankRepository>(compressedDirectory, directoryVersion);

      _logger.LogInformation("Загрузка справочника банков завершена");
    }

    private async Task ProcessBankCitiesDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.BankCitiesDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника городов ...");

            var compressedDirectory = contactDirectories.BankCitiesDirectory;

            await ProcessDirectory<BankCityModel, BankCity, BankCityMapper, BankCityRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника городов завершена");
        }
         
        private async Task ProcessBankServicesDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.BankServicesDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника услуг банков...");

            var compressedDirectory = contactDirectories.BankServicesDirectory;

            await ProcessDirectory<BankServModel, BankServ, BankServMapper, BankServRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника услуг банков завершена");
        }

        private async Task ProcessControlRulesDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.ControlRulesDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника правил контроля полей...");

            var compressedDirectory = contactDirectories.ControlRulesDirectory;

            await ProcessDirectory<ControlRuleModel, ControlRule, ControlRuleMapper, ControlRuleRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника правил контроля полей завершена");
        }

        private async Task ProcessCountryDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.CountriesDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника стран...");

            var compressedDirectory = contactDirectories.CountriesDirectory;

            await ProcessDirectory<CountryModel, Country, CountryMapper, CountryRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника стран завершена");
        }

        private async Task ProcessFeatureTextDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.FeatureTextDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника с текстовой информацией об особенностях обслуживания...");

            var compressedDirectory = contactDirectories.FeatureTextDirectory;

            await ProcessDirectory<FeatureCaptionModel, FeatureCaption, FeatureCaptionMapper, FeatureCaptionRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника с текстовой информацией об особенностях обслуживания завершена");
        }

        private async Task ProcessFeaturesDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.FeaturesDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника с информацией об особенностях обслуживания...");

            var compressedDirectory = contactDirectories.FeaturesDirectory;

            await ProcessDirectory<FeatureModel, Feature, FeatureMapper, FeatureRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника с информацией об особенностях обслуживания завершена");
        }

        private async Task ProcessFinancialMonitoringInfoDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.FinancialMonitoringInfoDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника с информацией о фин.мониторинге...");

            var compressedDirectory = contactDirectories.FinancialMonitoringInfoDirectory;

            await ProcessDirectory<FinancialMonitoringInfoModel, FinancialMonitoringInfo, FinancialMonitoringInfoMapper, FinancialMonitoringInfoRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника с информацией о фин.мониторинге завершена");
        }

        private async Task ProcessLimitsDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.LimitsDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника лимитов...");

            var compressedDirectory = contactDirectories.LimitsDirectory;

            await ProcessDirectory<LimitModel, Limit, LimitMapper, LimitRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника лимитов завершена");
        }

        private async Task ProcessLogosDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.LogosDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника логотипов...");

            var compressedDirectory = contactDirectories.LogosDirectory;

            await ProcessDirectory<LogoModel, Logo, LogoMapper, LogoRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника логотипов завершена");
        }

        private async Task ProcessMetroLinesDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.MetroLinesDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника линий метрополитена...");

            var compressedDirectory = contactDirectories.MetroLinesDirectory;

            await ProcessDirectory<MetroLineModel, MetroLine, MetroLineMapper, MetroLineRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника линий метрополитена завершена");
        }

        private async Task ProcessMetroStationsDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.MetroStationsDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника станций метро...");

            var compressedDirectory = contactDirectories.MetroStationsDirectory;

            await ProcessDirectory<MetroStationModel, MetroStation, MetroStationMapper, MetroStationRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника станций метро завершена");
        }

        private async Task ProcessRegionsDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.RegionsDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника регионов ...");

            var compressedDirectory = contactDirectories.RegionsDirectory;

            await ProcessDirectory<RegionModel, Region, RegionMapper, RegionRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника регионов завершена");
        }

        private async Task ProcessScenarioItemDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.ScenarioItemsDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника шагов сценария...");

            var compressedDirectory = contactDirectories.ScenarioItemsDirectory;

            await ProcessDirectory<ScenarioItemModel, ScenarioItem, ScenarioItemMapper, ScenarioItemRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника шагов сценария завершена");
        }

        private async Task ProcessServDirectory(ContactBusinessLevelResponse contactDirectories, int directoryVersion)
        {
            if (contactDirectories.ServicesDirectory == null)
            {
                return;
            }

            _logger.LogInformation("Загрузка справочника услуг...");

            var compressedDirectory = contactDirectories.ServicesDirectory;

            await ProcessDirectory<ServModel, Serv, ServMapper, ServRepository>(compressedDirectory, directoryVersion);

            _logger.LogInformation("Загрузка справочника услуг завершена");
        }

        private async Task ProcessDirectory<TDirectoryModel, TDirectory, TMapper, TRepository>(string compressedDirectory, int directoryVersion)
             where TDirectoryModel : IDirectoryModel
             where TDirectory : class, IDirectory
             where TMapper : IMapper<TDirectoryModel, TDirectory>, new()
             where TRepository : BaseRepository<TDirectory>
        {
            var directoryBin = UncompressBuffer(Convert.FromBase64String(compressedDirectory));

            var directoryString = Encoding.GetEncoding(1251).GetString(directoryBin);

            //Сериализовать в BorlandDatapacket
            TextReader textReader = new StringReader(directoryString);

            XmlSerializer serializer = new XmlSerializer(typeof(BorlandDatapacket<TDirectoryModel>));
            BorlandDatapacket<TDirectoryModel> directoriesPacket = null;
      try
      {
         directoriesPacket = serializer.Deserialize(textReader) as BorlandDatapacket<TDirectoryModel>;

      }
      catch (Exception err )
      {
        int tt = 0;
        throw;
      }

            if (directoriesPacket == null)
            {
                throw new ApplicationException("Не удалось десериализовать справочник!");
            }
            //Получить коллекцию строк в виде коллекции классов
            var entities = Array.ConvertAll(directoriesPacket.Directories, new TMapper().Map);

            //Произвести обновления в базе согласно свойствам Deleted и Version
            await _updatingService.UpdateDirectory<TDirectory, TRepository>(entities.ToList(), directoryVersion);
        }


        /// <summary>
        /// Распаковать архив
        /// </summary>
        /// <param name="buffer">Массив байт архива</param>
        /// <returns>Распакованный массив байт</returns>
        public static byte[] UncompressBuffer(byte[] buffer)
        {
            byte[] toDecompress = new byte[buffer.Length - 2];

            Array.Copy(buffer, 2, toDecompress, 0, toDecompress.Length);

            return Ionic.Zlib.DeflateStream.UncompressBuffer(toDecompress);
        }
    }
}
