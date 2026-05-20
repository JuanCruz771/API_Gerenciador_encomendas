using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;

namespace API_Gerendiador_Encomendas.DAO
{
    public class MoradorRepository : iMoradorRepository
    {
        private readonly ConnectionContext context;

        public MoradorRepository(ConnectionContext context)
        {
            this.context = context;
        }

        public void delete()
        {
            throw new NotImplementedException();
        }

        public List<MoradorModel>? GetAll()
        {
            return context.moradores.ToList();
        }

        public MoradorModel GetById(int id)
        {
            return context.moradores.FirstOrDefault(m => m.Id == id);
        }


        public void save(MoradorModel morador)
        {
            context.moradores.Add(morador);
            context.SaveChanges();
        }
        public void Update(MoradorModel morador)
        {
            context.moradores.Update(morador);
            context.SaveChanges();
        }
    }
}
