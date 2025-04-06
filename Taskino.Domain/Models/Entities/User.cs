using System.ComponentModel.DataAnnotations;
using Taskino.Domain.Models.Enums;

namespace Taskino.Domain.Models.Entities
{
    public class User:BaseEntity.BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Email { get; set; }
        [Required]
        public UserRole UserRole { get; set; }


        #region Relations
        public ICollection<Task>? Tasks { get; set; }
        #endregion
    }
}
