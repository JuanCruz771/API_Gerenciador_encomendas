using API_Gerendiador_Encomendas.Models;

namespace API_Gerendiador_Encomendas.Repositories
{
    public interface iMoradorRepository
    {
        List<MoradorModel> GetAll();

        MoradorModel GetById(int id);
        MoradorModel GetByCasa(string casa);
        void save(MoradorModel morador);
        void Update(MoradorModel morador );
        void delete();
    }
}
