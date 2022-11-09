using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TargetaCredito> TarjetaCredito { get; set; }
    }
}
