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

        public DbSet<DbModel.Company> Company { get; set; }
        public DbSet<DbModel.Product> Product { get; set; }
        public DbSet<DbModel.Experience> Experience { get; set; }
    }
}