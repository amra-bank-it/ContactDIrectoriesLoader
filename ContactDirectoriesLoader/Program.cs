using ContactDirectoriesLoader;
using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository;
using ContactDirectoriesLoader.Repository.Database;
using ContactDirectoriesLoader.Repository.Entities.Base;
using ContactDirectoriesLoader.Schedule;
using ContactDirectoriesLoader.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        services.AddHostedService<Worker>();
        services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddNLog();
            logging.AddConfiguration(configuration.GetSection("Logging"));
            LogManager.Configuration =
                new NLogLoggingConfiguration(configuration.GetSection("NLog"));
        });


        DatabaseSetup.Setup(services, configuration);

        services.AddSingleton<IDownloadingService, DownloadingService>();
        
        services.AddSingleton<IProcessingService, ProcessingService>();
        
        services.AddSingleton<IUpdatingService, UpdatingService>();

        services.AddTransient<IDbContext, DictionariesDbContext>();
        
        services.AddSingleton<IDirectoryLoadingService, DirectoryLoadingService>();

        services.Configure<JobOptions>(configuration.GetSection("JobOptions"));

        services.AddSingleton<IJob, DirectoryLoadingJob>();

        services.AddSingleton<IJobFactory, JobFactory>();

        services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

    })
    .UseWindowsService(options =>
        {
            options.ServiceName = "Contact Directories Loadering Service";
        })
    .Build();

DatabaseSetup.DbMigrate(host.Services);

await host.RunAsync();
