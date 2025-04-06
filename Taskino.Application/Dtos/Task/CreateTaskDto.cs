using Taskino.Domain.Models.Enums;

namespace Taskino.Application.Dtos.Task
{
    public class CreateTaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DoneDate { get; set; }
        public TaskLevel TaskLevel { get; set; }
        public long UserId { get; set; }
    }
}
