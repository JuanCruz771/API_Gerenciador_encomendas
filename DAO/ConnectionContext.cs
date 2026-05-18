using API_Gerendiador_Encomendas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Gerendiador_Encomendas.DAO
{
    public class ConnectionContext : DbContext
    {
        public DbSet<EncomendaModel> encomendas { get; set; }
        public DbSet<MoradorModel> moradores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbData = Environment.GetEnvironmentVariable("DB_DATA");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");

            var connectionString = $"Server={dbServer};Port={dbPort};Database={dbData};Username={dbUser};Password={dbPassword};";

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
