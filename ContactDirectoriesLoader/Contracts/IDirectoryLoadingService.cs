using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Contracts
{
    /// <summary>
    /// Основной класс-сервис загрузки справочноков
    /// </summary>
    /// <remarks>
    /// Сервис-координатор загрузки справоников. 
    /// Отвечает, среди прочего, за порционную загрузку.
    /// </remarks>
    public interface IDirectoryLoadingService
    {
        /// <summary>
        /// Загрузка, справочника, его обработка и обновление в базе.
        /// </summary>
        /// <returns>Задание.</returns>
        public Task Load(); 
    }
}
