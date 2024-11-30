using Machine_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineAccounting.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("name=AppDbContext");
        }
    }
}
