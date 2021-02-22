using KocDigitalPOC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KocDigitalPOC.Data
{
    public class KocDigitalDbContext : DbContext
    {
        public KocDigitalDbContext(DbContextOptions<KocDigitalDbContext> options) : base(options)
        {
            
        }

        public DbSet<DataFrame> DataFrames { get; set; }


    }
}