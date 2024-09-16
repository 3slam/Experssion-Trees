using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Experssion_Trees.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PassengerInfo> PassengerInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HF7R40U;Database=Passenger;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;");
        }

        
    }
}
