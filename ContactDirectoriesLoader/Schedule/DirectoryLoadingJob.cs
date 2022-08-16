using ContactDirectoriesLoader.Contracts;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Schedule
{
    public class DirectoryLoadingJob : IJob
    {
        private readonly IDirectoryLoadingService _directoryLoadingService;
        private readonly ILogger<DirectoryLoadingJob> _logger;

        public DirectoryLoadingJob(IDirectoryLoadingService directoryLoadingService,
                                   ILogger<DirectoryLoadingJob> logger)
        {
            _directoryLoadingService = directoryLoadingService;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogInformation("Старт задания загрузки...");

                await _directoryLoadingService.Load();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка. {ex.Message}"); 
            }
        }
    }
}
