using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.WebApp.Models;

namespace StudentRegistrationSystem.WebApp.Repository
{
    public class BaseDbContext:DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=S; Trusted_Connection=true");
        }



        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }





    }
}
