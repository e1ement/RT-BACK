using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ValueEntity> Values { get; set; }
        public DbSet<FtpSettingsEntity> FtpSettings { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserTaskEntity> UserTasks { get; set; }
        public DbSet<DialogEntity> Dialogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTaskEntity>(v =>
            {
                v.HasKey(k => new { k.UserId, k.TaskId });
                v.HasOne(o => o.Task)
                    .WithMany(m => m.Users)
                    .HasForeignKey(fk => fk.TaskId)
                    .HasPrincipalKey(t => t.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                v.HasOne(o => o.User)
                    .WithMany(m => m.Tasks)
                    .HasForeignKey(fk => fk.UserId)
                    .HasPrincipalKey(t => t.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<DialogEntity>(v =>
            {
                v.HasKey(k => k.Id);
                v.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
                v.HasOne(o => o.Task)
                    .WithMany(m => m.Dialogs)
                    .HasForeignKey(fk => fk.TaskId)
                    .HasPrincipalKey(t => t.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                v.HasOne(o => o.User)
                    .WithMany(m => m.Dialogs)
                    .HasForeignKey(fk => fk.UserId)
                    .HasPrincipalKey(t => t.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
