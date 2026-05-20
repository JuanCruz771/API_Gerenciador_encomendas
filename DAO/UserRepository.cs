using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;
using API_Gerendiador_Encomendas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Gerendiador_Encomendas.DAO
{
    public class UserRepository : iUserRepository
    {
        private readonly ConnectionContext context;
        private readonly IConfiguration _config;

        public UserRepository(ConnectionContext context)
        {
            this.context = context;
        }

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
            return context.usuarios.FirstOrDefault(e => e.Id == id);
        }

        public void login(Usermodel user)
        {
            throw new NotImplementedException();
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
