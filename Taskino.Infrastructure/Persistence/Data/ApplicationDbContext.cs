using Microsoft.EntityFrameworkCore;
using Taskino.Domain.Models.Entities;

namespace Taskino.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.SetNull;
            }
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<PendUserRegister> PendUserRegisters { get; set; }
        public DbSet<Domain.Models.Entities.Task> Tasks { get; set; }
    }
}
