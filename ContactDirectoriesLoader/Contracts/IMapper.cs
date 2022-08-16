using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Contracts
{
    /// <summary>
    /// Интерфейс маппера
    /// </summary>
    internal interface IMapper<TDirectoryModel, TEntity>
        where TDirectoryModel : IDirectoryModel
        where TEntity : IEntity
    {
        public TEntity Map(TDirectoryModel model);
    }
}
