using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;

namespace API_Gerendiador_Encomendas.DAO
{
    public class UserRepository : iUserRepository
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

        public List<Usermodel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usermodel GetById(int id)
        {
            return context.usuarios.FirstOrDefault(e => e.id == id);
        }


        public void save(Usermodel user)
        {
            context.usuarios.Add(user);
            context.SaveChanges();
        }
        public void Update(Usermodel user)
        {
            context.usuarios.Update(user);
            context.SaveChanges();
        }
    }
}
