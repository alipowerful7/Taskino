using System.ComponentModel.DataAnnotations;

namespace Taskino.Domain.Models.Entities
{
    public class PendUserRegister:BaseEntity.BaseEntity
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
        [MaxLength(20)]
        public string? ConfirmationCode { get; set; }
        [Required]
        public DateTime CodeExpiresAt { get; set; }
    }
}
