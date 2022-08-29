using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ContactDirectoriesLoader.Repository.Entities.Base;
using ContactDirectoriesLoader.Repository.Entities;
using EFCore.BulkExtensions;

namespace ContactDirectoriesLoader.Repository.Database
{
    public class DictionariesDbContext : DbContext, IDbContext
    {
        public DictionariesDbContext(DbContextOptions<DictionariesDbContext> options) : base(options)
        {

        }

        public DatabaseFacade GetDatabase()
        {
            return Database;
        }

        public DbSet<ControlRule> ControlRules { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<BadDoc> BadDocs { get; set; }
    public DbSet<BankCity> BankCities { get; set; }
        public DbSet<BankServ> BankServices { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureCaption> FeatureCaptions { get; set; }
        public DbSet<FinancialMonitoringInfo> FinancialMonitoringInfos { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<MetroLine> MetroLines { get; set; }
        public DbSet<MetroStation> MetroStations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ScenarioItem> ScenarioItems { get; set; }
        public DbSet<Serv> Serves { get; set; }
        public DbSet<LoadingInfo> LoadingInfos { get; set; }

        /// <summary>
        /// Вставка несколько записей в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks"></param>
        /// <param name="setOutputIdentity">true - проставляет во всех переданных объектах новый идентификатор, полученный при вставке.
        public async Task InsertAsync<T>(List<T> values, bool setOutputIdentity = true) where T : class
        {
            await this.BulkInsertAsync(values, config =>
            {
                config.SetOutputIdentity = setOutputIdentity;
                config.PreserveInsertOrder = setOutputIdentity;
                config.BulkCopyTimeout = 180;
            });
        }
    }
}
