using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;
using Microsoft.AspNetCore.Connections;

namespace API_Gerendiador_Encomendas.DAO

{
    public class EncomendaRepository : iEncomendaRepository
    {
        private readonly ConnectionContext context = new ConnectionContext();

        public void delete()
        {
            throw new NotImplementedException();
        }

        public List<EncomendaModel> Get()
        {
            return context.encomendas.ToList();
        }

        public List<EncomendaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EncomendaModel GetById(int id)
        {
            return context.encomendas.FirstOrDefault(e => e.Id == id);
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
    }
}
