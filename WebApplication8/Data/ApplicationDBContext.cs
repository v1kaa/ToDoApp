using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<ToDoModel> ToDoApp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoModel>().HasData(
                new ToDoModel
                {
                    Id = 1,
                    Task = "Task 1",
                    IsCompleted = false
                },
                new ToDoModel
                {
                    Id = 2,
                    Task = "Task 2",
                    IsCompleted = false
                },
                new ToDoModel
                {
                    Id = 3,
                    Task = "Task 3",
                    IsCompleted = false
                }
            );
        }
    }
}
