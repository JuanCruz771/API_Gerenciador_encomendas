using API_Gerendiador_Encomendas.Models;

namespace API_Gerendiador_Encomendas.Repositories
{
    public interface iUserRepository
    {
        List<Usermodel> GetAll();

        Usermodel GetById(int id);
        void save(Usermodel user);
        void Update(Usermodel user);
        void delete();

    }
}
