using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ContactDirectoriesLoader.Repository.Entities.Base
{
    public interface IDbContext
    {
        ChangeTracker ChangeTracker { get; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken token = default);

        DatabaseFacade GetDatabase();

        DbSet<ControlRule> ControlRules{ get; set; }
    DbSet<BadDoc> BadDocs { get; set; }
    DbSet<Bank> Banks { get; set; }
    DbSet<BankCity> BankCities { get; set; }
        DbSet<BankServ> BankServices { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<FeatureCaption> FeatureCaptions { get; set; }
        DbSet<FinancialMonitoringInfo> FinancialMonitoringInfos { get; set; }
        DbSet<Limit> Limits { get; set; }
        DbSet<Logo> Logos { get; set; }
        DbSet<MetroLine> MetroLines { get; set; }
        DbSet<MetroStation> MetroStations { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<ScenarioItem> ScenarioItems { get; set; }
        DbSet<Serv> Serves { get; set; }
        DbSet<LoadingInfo> LoadingInfos { get; set; }

        /// <summary>
        /// Вставка несколько записей в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks"></param>
        /// <param name="setOutputIdentity">true - проставляет во всех переданных объектах новый идентификатор, полученный при вставке.
        Task InsertAsync<T>(List<T> values, bool setOutputIdentity = true) where T : class;
    }
}