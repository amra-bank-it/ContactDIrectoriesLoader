using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Repository.Base
{
    public interface IRepository : IDisposable
    {

    }

    public interface IRepository<TEntity> : IRepository where TEntity : IEntity
    {

        Task InsertAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entityToDelete);
        Task<int> SaveChangesAsync();
        Task UpdateAsync(TEntity entityToUpdate);

        /// <summary>
        /// Сохранить или обновить сущность
        /// </summary>
        /// <param name="entityToSave">Сущность</param>
        /// <param name="needUploadChanges">отправлять ли содержимое контекста в базу или накапливать</param>
        /// <returns></returns>
        Task SaveAsync(TEntity entityToSave, bool needUploadChanges = false);
    }
}
