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

        public EncomendaModel GetByCodName(string codigo,string nome)
        {
            return context.encomendas
           .FirstOrDefault(e =>
               e.Codigo == codigo &&
               e.Nome_morador == nome
       );
        }

        public async Task<int> DeleteByMorador(int id_morador)
        {
            return await context.encomendas
                .Where(e =>
                    e.Id_morador == id_morador &&
                    e.Data_entrega == null
                )
                .ExecuteDeleteAsync();
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