using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Schedule;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Spi;

namespace ContactDirectoriesLoader
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDirectoryLoadingService _directoryLoadingService;
        private IScheduler _scheduler;
        private readonly JobOptions _settings;

        public Worker(ILogger<Worker> logger,
                      IDirectoryLoadingService directoryLoadingService,
                      ISchedulerFactory schedulerFactory,
                      IJobFactory jobFactory,
                      IOptions<JobOptions> settings)
        {
            _logger = logger;
            _directoryLoadingService = directoryLoadingService;
            _settings = settings.Value;
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.JobFactory = jobFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Сервис запущен в: {time}", DateTimeOffset.Now);

            var jobSchedule = _settings.Schedules.FirstOrDefault(); //пока джоб только один

            try
            {
                IJobDetail job = CreateJob(jobSchedule.Key);
                ITrigger trigger = CreateTrigger(jobSchedule.Key, jobSchedule.Value);
                await _scheduler.ScheduleJob(job, trigger, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при создании задачи {jobSchedule.Key}");
            }

            try
            {
                await _scheduler.Start(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при старте планировшика");
            }
        }

        /// <summary>
        /// Создает джоб
        /// </summary>
        /// <returns></returns>
        private static IJobDetail CreateJob(string jobName)
        {
            var jobType = Type.GetType(jobName);
            if (jobType == null)
            {
                throw new TypeLoadException($"Не найден тип {jobName}");
            }

            return JobBuilder
                .Create(jobType)
                .WithIdentity(jobName)
                .WithDescription(jobName)
                .Build();
        }

        /// <summary>
        /// Создает расписание
        /// </summary>
        /// <returns></returns>
        private static ITrigger CreateTrigger(string jobName, string schedule)
        {
            var type = Type.GetType(jobName);
            if (type == null)
                throw new TypeLoadException($"Не найден тип {jobName}");

            return TriggerBuilder
                .Create()
                .WithCronSchedule(schedule)
                .StartNow()
                .WithIdentity($"{type.FullName}.trigger")
                .WithDescription(schedule)
                .Build();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker завершает работу.");
            _scheduler.Clear(cancellationToken);
            _scheduler.Shutdown(cancellationToken);
            NLog.LogManager.Shutdown();
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
            _scheduler = null;
        }

    }
}