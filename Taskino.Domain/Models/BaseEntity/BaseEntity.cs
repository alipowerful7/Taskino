using System.ComponentModel.DataAnnotations;

namespace Taskino.Domain.Models.BaseEntity
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
