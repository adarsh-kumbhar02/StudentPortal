using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Data
{
    public class StudentPortalContext : DbContext
    {
        public StudentPortalContext(DbContextOptions<StudentPortalContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}