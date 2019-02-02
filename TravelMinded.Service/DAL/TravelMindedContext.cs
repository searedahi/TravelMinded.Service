using Microsoft.EntityFrameworkCore;

namespace TravelMinded.Service.DAL
{
    public class TravelMindedContext : DbContext
    {
        public TravelMindedContext()
            : base() { }

        /// <summary>
        /// Used by DI in admin site
        /// </summary>
        /// <param name="options"></param>
        public TravelMindedContext(DbContextOptions<TravelMindedContext> options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=TravelMinded;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        

        public DbSet<DbModel.Company> Companies { get; set; }
        public DbSet<DbModel.Product> Products { get; set; }
        public DbSet<DbModel.Experience> Experiences { get; set; }
        public DbSet<DbModel.Availability> Availabilities { get; set; }
        public DbSet<DbModel.Tag> Tags { get; set; }

        public DbSet<DbModel.ProTip> ProTips { get; set; }

    }
}