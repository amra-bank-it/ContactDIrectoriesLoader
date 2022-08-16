using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository.Base;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Contracts
{
    /// <summary>
    /// Сервис обновления справочников банка
    /// </summary>
    public interface IUpdatingService
    {
        /// <summary>
        /// Обновить справочник.
        /// </summary>
        /// <param name="directory">Справочник</param>
        /// <param name="directoryVersion">Версия загружаемого справочника</param>
        public Task UpdateDirectory<TDirectory, TRepository>(List<TDirectory> directory, int? directoryVersion = null)
            where TDirectory : class, IDirectory
            where TRepository : BaseRepository<TDirectory>;

        /// <summary>
        /// Сохранить в базе общую информацию о загрузке.
        /// </summary>
        /// <param name="response">Ответ Contact бизнес-уровня.</param>
        /// <param name="directoryVersion">Загружаемая версия справочника.</param>
        /// <param name="startDateTime">Дата и время первого запроса.</param>
        Task SaveLoadingInfo(ContactBusinessLevelResponse response, int directoryVersion, DateTime? startDateTime = null);
    }
}
