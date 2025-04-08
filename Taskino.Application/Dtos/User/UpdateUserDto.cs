namespace Taskino.Application.Dtos.User
{
    public class UpdateUserDto
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? UserName { get; set; }
    }
}
