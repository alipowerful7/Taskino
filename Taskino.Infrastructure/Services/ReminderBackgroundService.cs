using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taskino.Application.Interfaces;
using Taskino.Domain.Interfaces;

namespace Taskino.Infrastructure.Services
{
    public class ReminderBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ReminderBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var taskRepository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    var tasks = await taskRepository.GetTasksForReminder(DateTime.UtcNow.AddDays(1));

                    foreach (var task in tasks)
                    {
                        await emailService.SendReminderEmailAsync(task.User?.Email!, task.Title!);
                        task.IsReminderSent = true;
                        await taskRepository.TrueReminderSent(task.Id);
                    }
                }
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
