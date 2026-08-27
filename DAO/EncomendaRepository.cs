using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API_Gerendiador_Encomendas.DAO
{
    public class EncomendaRepository : iEncomendaRepository
    {
        private readonly ConnectionContext context;

        public EncomendaRepository(ConnectionContext context)
        {
            this.context = context;
        }

        public List<EncomendaModel>? GetAll()
        {
            return context.encomendas.ToList();
        }

        public EncomendaModel GetById(int id)
        {
            return context.encomendas
                .FirstOrDefault(e => e.Id == id);
        }

        public void save(EncomendaModel encomenda)
        {
            context.encomendas.Add(encomenda);

            context.SaveChanges();
        }

        

        public void Delete(int id)
        {
             context.encomendas
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync();
        }

        public void Update(EncomendaModel encomenda)
        {
            context.SaveChanges();
        }
    }
}