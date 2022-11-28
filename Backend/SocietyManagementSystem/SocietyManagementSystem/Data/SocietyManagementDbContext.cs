using Microsoft.EntityFrameworkCore;
using SocietyManagementSystem.Models.Entities;
using System.Reflection.Emit;

namespace SocietyManagementSystem.Data
{
    public class SocietyManagementDbContext : DbContext
    {
        public SocietyManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<FinanceDepartment> FinanceDepartments { set; get; }
        public DbSet<Society> Societies { set; get; }
        public DbSet<Event> Events { set; get; }
        public DbSet<Registration> Registrations { set; get; }


    }
}
