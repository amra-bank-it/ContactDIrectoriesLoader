using ContactDirectoriesLoader.Repository.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Repository.Database
{
    public static class DatabaseSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDbContext, DictionariesDbContext>(options =>
            {
                var connectionString = configuration["ConnectionStrings:DictionariesConnectionString"];
                options.UseSqlServer(connectionString, providerOptions =>
                {
                    providerOptions.CommandTimeout(300);
                    providerOptions.EnableRetryOnFailure(5, TimeSpan.FromMilliseconds(500), null);
                });
            }, ServiceLifetime.Transient);

            services.AddTransient<Func<IDbContext>>(x =>
            {
                var dbContext = x.GetService<IDbContext>();
                return () => dbContext;
            });

            services.AddTransient<BankCityRepository>();
            services.AddTransient<BankRepository>();
            services.AddTransient<BankServRepository>();
            services.AddTransient<ControlRuleRepository>();
            services.AddTransient<CountryRepository>();
            services.AddTransient<FeatureCaptionRepository>();
            services.AddTransient<FeatureRepository>();
            services.AddTransient<FinancialMonitoringInfoRepository>();
            services.AddTransient<LimitRepository>();
            services.AddTransient<LogoRepository>();
            services.AddTransient<MetroLineRepository>();
            services.AddTransient<MetroStationRepository>();
            services.AddTransient<RegionRepository>();
            services.AddTransient<ScenarioItemRepository>();
            services.AddTransient<ServRepository>();
            services.AddTransient<LoadingInfoRepository>();
        }

        public static void DbMigrate(IServiceProvider services)
        {
            using (var serviceScope = services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IDbContext>();
                context.GetDatabase().Migrate();
            }
        }
    }
}
