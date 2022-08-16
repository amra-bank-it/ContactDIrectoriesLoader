using ContactDirectoriesLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Contracts
{
    /// <summary>
    /// Сервис получения справочников
    /// </summary>
    public interface IDownloadingService
    {
        /// <summary>
        /// Загрузить XML-справочник банков  
        /// </summary>
        /// <param name="updatesOnly">загружать только обновления.</param>
        /// <returns>Ответ бизнес-уровня из Contact</returns>
        public Task<ContactBusinessLevelResponse> LoadDirectories();


        /// <summary>
        /// Загрузить XML-справочник банков (с параметрами)
        /// </summary>
        /// <param name="PartitionDirectoryId">Идентификатор справочника, разбиваемого на части</param>
        /// <param name="CurrentDirectoryPart">Текущая загружаемая часть справочника</param>
        /// <returns>>Ответ бизнес-уровня из Contact</returns>
        public Task<ContactBusinessLevelResponse> LoadDirectories(string PartitionDirectoryId, int CurrentDirectoryPart);
    }
}
