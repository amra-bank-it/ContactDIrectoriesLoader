using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Repository.Entities.Base
{
    /// <summary>
    /// Базовый интерфейс для всех сущностей БД
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Версия записи
        /// </summary>
        int Version { get; set; }

        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        int Id { get; set; }
    }
}
