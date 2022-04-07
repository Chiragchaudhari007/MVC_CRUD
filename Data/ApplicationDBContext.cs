using Microsoft.EntityFrameworkCore;
using MVC.Models;
namespace MVC.Data              
{
   public class ApplicationDBContext: DbContext
    {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
             
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }

    }
}