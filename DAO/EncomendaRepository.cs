using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;

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

        public void save(EncomendaModel estoque)
        {
            context.encomendas.Add(estoque);

            context.SaveChanges();
        }

        public void Update(EncomendaModel estoque)
        {
            context.encomendas.Update(estoque);

            context.SaveChanges();
        }

        public void delete()
        {
            throw new NotImplementedException();
        }
    }
}