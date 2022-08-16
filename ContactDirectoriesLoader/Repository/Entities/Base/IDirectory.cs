using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Repository.Entities.Base
{
    /// <summary>
    /// Справочник CONTACT
    /// </summary>
    public interface IDirectory : IEntity
    {
        /// <summary>
        /// Флаг, указывающий на то, что запись об участнике системы подлежит
        /// удалению из справочника на стороне клиента.
        /// 0 – запись удалению не подлежит.
        /// 1 – запись подлежит удалению.
        /// </summary>
        bool Erased { get; set; }
    }
}
