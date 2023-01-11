global using Microsoft.EntityFrameworkCore;// do not forget to make it global

namespace SuperHeroAPIDotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=superherodb; Trusted_Connection=true; TrustServerCertificate=true;");
            //TODO: ПЕРЕПИСАТЬ КОНФИГИ APPSETTINGS 
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
