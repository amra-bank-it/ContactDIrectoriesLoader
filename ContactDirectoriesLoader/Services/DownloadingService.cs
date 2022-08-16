using ContactDirectoriesLoader.Common;
using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Services
{
    /// <summary>
    /// Сервис получения справочников
    /// </summary>
    public class DownloadingService : IDownloadingService
    {
        private readonly ILogger<DownloadingService> _logger;
        //private readonly IDbContext _dbContext;
        private readonly IServiceProvider _services;

        private string _pointCode = "";
        private string _ngServerUrl = "";
        private string _intSoftId = "";
        private string _pack = "";
        private bool _needLoadByParts = false;
        private bool _needLoadFullDirectory = false;

        /// <summary>
        /// .ctor
        /// </summary>
        public DownloadingService(ILogger<DownloadingService> logger,
                                  IServiceProvider services)
        {
            _logger = logger;
            _services = services;
            //_dbContext = GetDbContext();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }


        /// <summary>
        /// Загрузить XML-справочник банков (с параметрами)
        /// </summary>
        /// <returns>>Ответ бизнес-уровня из Contact</returns>
        public async Task<ContactBusinessLevelResponse> LoadDirectories()
        {
            return await LoadDirectories("", -1);
        }


        /// <summary>
        /// Загрузить XML-справочник банков  
        /// </summary>
        /// <param name="updatesOnly">загружать только обновления.</param>
        /// <param name="currenVersion">Текущая версия справочника. Для полного спраовника  = 0 </param>
        /// <returns>XML-строка со справочником банков</returns>
        public async Task<ContactBusinessLevelResponse> LoadDirectories(string partitionDirectoryId, int currentDirectoryPart)
        {
            const int MaxResponseWaitMinutes = 30;

            GetSettings();

            int currentVersion = _needLoadFullDirectory ?  0 : GetCurrentVersionNumber();
            
            var getDirectoriesRequest = GetDirectoriesRequest(currentVersion, partitionDirectoryId, currentDirectoryPart);

            _logger.LogInformation($"Запрос справочника: {getDirectoriesRequest}");

            var content = new StringContent(getDirectoriesRequest, Encoding.GetEncoding(1251), "text/xml");

            byte[] responseContent;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, MaxResponseWaitMinutes, 0); 
                    
                    var response = await httpClient.PutAsync(_ngServerUrl, content);

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        _logger.LogError("Сетевой код ошибки: {code}, текст ошибки {text}", response.StatusCode, response.ReasonPhrase);
                    }

                    responseContent = await response.Content.ReadAsByteArrayAsync();

                }

                var responseString = Encoding.GetEncoding(1251).GetString(responseContent);

                if (responseString == null)
                {
                    throw new ApplicationException($"response String is null!");
                }

                if (responseString != null)
                {
                    File.WriteAllText(@"D:\Projects\DictionaryLoader\ContactDir_prod_full_20220330.txt", responseString, System.Text.Encoding.GetEncoding(1251));
                }

                TextReader textReader = new StringReader(responseString);

                XmlSerializer serializer = new XmlSerializer(typeof(ContactBusinessLevelResponse));

                var contactResponse = serializer.Deserialize(textReader) as ContactBusinessLevelResponse;

                if (contactResponse == null)
                {
                    throw new ApplicationException("Не удалось десериализовать справочник!");
                }

                if (contactResponse.Re != 0)
                {
                    throw new ApplicationException($"Ошибка. Ответ бизнес-уровня: {contactResponse.Re} : {contactResponse.ErrorText}");
                }

                return contactResponse;
            }
            catch (HttpRequestException exc)
            {
                _logger.LogError(exc, "Ошибка запроса получения справочника: {err}", exc.Message);
                throw;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "Ошибка получения справочника: {err}", exc.Message);
                throw;
            }
        }

        /// <summary>
        /// Получить текст запроса
        /// </summary>
        /// <param name="updatesOnly">загружать только обновления.</param>
        /// <param name="currenVersion">Текущая версия справочника. Для полного спраовника  = 0 </param>
        /// <returns></returns>
        private string GetDirectoriesRequest(long currentVersion, string PartitionDirectoryId, int CurrentDirectoryPart)
        {
            var request = new ContactBusinessLevelRequest()
            {
                ObjectClass = "TAbonentObject",
                Action = "GET_CHANGES",
                PointCode = $"{_pointCode}",
                IntSoftd = $"{_intSoftId}",
                Version = $"{currentVersion}",
                TypeVersion = "I",
                Pack = $"{_pack}",
                BookId = string.IsNullOrWhiteSpace(PartitionDirectoryId) ? "" : PartitionDirectoryId,
                Portion = _needLoadByParts ? "1" : "",
                Part = CurrentDirectoryPart < 0 ? "" : $"{CurrentDirectoryPart}",
                SignOut = "Yes",
                ExpectSigned = "No",
            };

            return SerializeObject<ContactBusinessLevelRequest>(request);

        }

        /// <summary>
        /// Получить номер текущей версии справочника
        /// </summary>
        /// <returns>Номер текущей версии справочника</returns>
        private int GetCurrentVersionNumber()
        {
            using (var scope = _services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IDbContext>();

                var loadingInfoEntity =  dbContext?
                                          .LoadingInfos?
                                          .OrderByDescending(record => record.StartDateTime)? //есть подозрения, что версия может уменьшиться, поэтому сортировка - по дате загрузки
                                         .FirstOrDefault();

                return loadingInfoEntity?.Version ?? 0;
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

        private void GetSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _pointCode = configuration["ContactNgServerConfigs:PointCode"];
            _intSoftId = configuration["ContactNgServerConfigs:IntSoftId"];
            _pack = configuration["ContactNgServerConfigs:Pack"];
            _needLoadByParts = Convert.ToBoolean(configuration["LoadByParts"]);
            _needLoadFullDirectory = Convert.ToBoolean(configuration["LoadFullDirectory"]);

            string host = configuration["ContactNgServerConfigs:Host"];
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            string port = configuration["ContactNgServerConfigs:Port"];

            _ngServerUrl = String.IsNullOrWhiteSpace(port) ? host : $"{host}:{port}";
        }

        public static string SerializeObject<T>(T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
