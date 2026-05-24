using API_Gerendiador_Encomendas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Gerendiador_Encomendas.DAO
{
    public class ConnectionContext : DbContext
    {
        
            public ConnectionContext(
                DbContextOptions<ConnectionContext> options)
                : base(options)
            {
            }

            public DbSet<EncomendaModel> encomendas { get; set; }

            public DbSet<MoradorModel> moradores { get; set; }

            public DbSet<Usermodel> usuarios { get; set; }

        }
}
