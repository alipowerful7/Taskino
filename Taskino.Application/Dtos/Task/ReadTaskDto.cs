namespace Taskino.Application.Dtos.Task
{
    public class ReadTaskDto
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DoneDate { get; set; }
        public bool IsCompleted { get; set; }
        public string? TaskLevel { get; set; }
        public long UserId { get; set; }
    }
}
