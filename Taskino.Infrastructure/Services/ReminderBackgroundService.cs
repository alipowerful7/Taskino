using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taskino.Application.Interfaces;
using Taskino.Domain.Interfaces;

namespace Taskino.Infrastructure.Services
{
    public class ReminderBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmailService _emailService;

        public ReminderBackgroundService(IServiceProvider serviceProvider, IEmailService emailService)
        {
            _serviceProvider = serviceProvider;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var taskRepository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
                    var tasks = await taskRepository.GetTasksForReminder(DateTime.UtcNow.AddDays(1));

                    foreach (var task in tasks)
                    {
                        await _emailService.SendReminderEmailAsync(task.User?.Email!, task.Title!);
                        task.IsReminderSent = true;
                        await taskRepository.TrueReminderSent(task.Id);
                    }
                }
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
