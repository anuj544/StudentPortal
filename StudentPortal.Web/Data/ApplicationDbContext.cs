using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
            
        }

        public  DbSet<Student> Students { get; set; }
    }
}
