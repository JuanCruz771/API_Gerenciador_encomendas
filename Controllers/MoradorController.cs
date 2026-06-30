using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Gerendiador_Encomendas.Controllers
{
    [Authorize]
    [Route("API/Morador")]
    public class MoradorController : Controller
    {
        private readonly iMoradorRepository morador_repositorie;

        public MoradorController(iMoradorRepository morador_repositorie)
        {
            this.morador_repositorie = morador_repositorie;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var morador = morador_repositorie.GetAll();
            return Ok(morador);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var morador = morador_repositorie.GetById(id);

            return Ok(morador);
        }

        [Authorize]
        [HttpGet("{casa}")]
        public IActionResult GetByCasa(string casa)
        {
            var morador = morador_repositorie.GetByCasa(casa);

            return Ok(morador);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] MoradorModel morador)
        {
            var mor = new MoradorModel
            {
                
                Nome = morador.Nome,
                Email = morador.Email,
                Numero = morador.Numero
            };

            this.morador_repositorie.save(mor);
            return Ok();
        }


        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MoradorModel morador)
        {
            var moradorexist = this.morador_repositorie.GetById(id);

            if (moradorexist == null) { return NotFound(); }

            var moradorupdate = new MoradorModel
            {
                Id = id,
                Nome = morador.Nome,
                Email = morador.Email,
                Numero = morador.Numero
            };

            this.morador_repositorie.Update(moradorupdate);
            return Ok();

        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
