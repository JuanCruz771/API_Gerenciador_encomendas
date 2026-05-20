using API_Gerendiador_Encomendas.DAO;
using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;
using API_Gerendiador_Encomendas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Gerendiador_Encomendas.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly iUserRepository usuario;
        private readonly IConfiguration _config;
        private readonly TokenService _tokenService;
        private readonly ConnectionContext _context;

        public AuthController(iUserRepository usuario, IConfiguration config, TokenService tokenService, ConnectionContext context)
        {
            this.usuario = usuario;
            _config = config;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usermodel login)
        {
            var user = _context.usuarios
         .FirstOrDefault(u => u.Password == login.Password && (u.Nome == login.Nome || u.Email == login.Email));

            if (user == null)
                return Unauthorized("Usuário ou senha inválidos");

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}