using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ContactDirectoriesLoader.Repository.Entities.Base;

namespace ContactDirectoriesLoader.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbContext _dbContext;
        internal DbSet<TEntity> DbSet { get; }
        private bool _disposed;

        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;

            DbSet = dbContext.Set<TEntity>();
        }

         public virtual async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        /// <summary>
        /// Вставка несколько записей в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks"></param>
        /// <param name="setOutputIdentity">true - проставляет во всех переданных объектах новый идентификатор, полученный при вставке.
        public async Task AddBatchAsync<T>(List<T> dictionaries, bool setOutputIdentity = true) where T : class
        {
            await _dbContext.InsertAsync(dictionaries, setOutputIdentity);
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await DbSet.FindAsync(id);

            await UpdateAsync(entityToDelete);
        }

        private void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual async Task SaveAsync(TEntity entityToSave, bool needUploadChanges = false)
        {
            var entity = DbSet.Find(entityToSave.Id);
            if (entity == null)
            {
                await InsertAsync(entityToSave); 
            }
            else
            {
                await Task.Run(() =>
                {
                    _dbContext.Entry(entity).CurrentValues.SetValues(entityToSave);
                    _dbContext.Entry(entity).State = EntityState.Modified;
                });
            }
            if (needUploadChanges)
            {
                await SaveChangesAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            var items = _dbContext.ChangeTracker.Entries().Where(x =>
                x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified);

            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
            //Записать в лог
            }
            return result;
        }

        public virtual async Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Run(() => Delete(entityToDelete));
        }

        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                var entity = DbSet.Find(entityToUpdate.Id);
                if (entity == null)
                    throw new ArgumentException($"Не найдена сущность с идентификатором {entityToUpdate.Id}");
                _dbContext.Entry(entity).CurrentValues.SetValues(entityToUpdate);
                _dbContext.Entry(entity).State = EntityState.Modified;
            });
        }


        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

