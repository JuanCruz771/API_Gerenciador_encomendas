using API_Gerendiador_Encomendas.Models;

namespace API_Gerendiador_Encomendas.Repositories
{
    
    public interface EncomdaRepository
    {
        List<EncomendaModel> GetAll();

        EncomendaModel GetById(int id);
        void save(EncomendaModel encomenda);
        void Update(EncomendaModel encomenda);
        void delete();

    }
}
