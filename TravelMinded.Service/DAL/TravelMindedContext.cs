using Microsoft.EntityFrameworkCore;

namespace TravelMinded.Service.DAL
{
    public class TravelMindedContext : DbContext
    {
        public TravelMindedContext() 
            : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=TravelMinded;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<DbModel.Company> Companies { get; set; }
        public DbSet<DbModel.Product> Products { get; set; }
        public DbSet<DbModel.Experience> Experiences { get; set; }
        public DbSet<DbModel.Availability> Availabilities { get; set; }
        public DbSet<DbModel.Tag> Tags { get; set; }

    }
}