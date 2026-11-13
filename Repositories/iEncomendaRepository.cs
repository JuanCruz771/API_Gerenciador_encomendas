using API_Gerendiador_Encomendas.Models;

namespace API_Gerendiador_Encomendas.Repositories
{
    
    public interface iEncomendaRepository
    {
        List<EncomendaModel> GetAll();

        EncomendaModel GetById(int id);

        EncomendaModel GetByCodName(string codigo, string nome);

        Task<int> DeleteByMorador(int id_morador);
        void save(EncomendaModel encomenda);
        void Update(EncomendaModel encomenda);
        void Delete(int id);

    }
}
