namespace Taskino.Application.Dtos.Task
{
    public class UpdateTaskDto
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DoneDate { get; set; }
        public bool IsCompleted { get; set; }
        public Domain.Models.Enums.TaskLevel TaskLevel { get; set; }
    }
}
