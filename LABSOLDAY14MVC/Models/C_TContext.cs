using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LABSOLDAY14MVC.Models
{
    public class C_TContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1PBR8C3\\SQLEXPRESS;Initial Catalog=Course_Trainee;User ID=sa;Password=dodysameh20; trust server certificate = true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Crs_Result> Crs_Result { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        

    }
}

