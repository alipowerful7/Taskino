using System.ComponentModel.DataAnnotations;
using Taskino.Domain.Models.Enums;

namespace Taskino.Domain.Models.Entities
{
    public class Task : BaseEntity.BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string? Description { get; set; }
        [Required]
        public DateTime DoneDate { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public TaskLevel TaskLevel { get; set; }
        [Required]
        public bool IsReminderSent { get; set; }


        #region Relations
        public User? User { get; set; }
        public long? UserId { get; set; }
        #endregion
    }
}
