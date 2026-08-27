using API_Gerendiador_Encomendas.DAO;
using API_Gerendiador_Encomendas.Models;
using API_Gerendiador_Encomendas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Gerendiador_Encomendas.Controllers
{

    [Authorize]
    [Route("API/Encomenda")]
    [ApiController]
    public class EncomendaController : ControllerBase
    {

        private readonly iEncomendaRepository encomenda_repositorie;

        public EncomendaController(iEncomendaRepository encomenda_repositorie)
        {
            this.encomenda_repositorie = encomenda_repositorie;
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var encomenda = encomenda_repositorie.GetAll();
            return Ok(encomenda);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var encomenda = encomenda_repositorie.GetById(id);

            return Ok(encomenda);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] EncomendaModel encomeda)
        {
            var encomenda = new EncomendaModel
            {
                Codigo = encomeda.Codigo,
                Nome_morador = encomeda.Nome_morador,
                Id_morador = encomeda.Id_morador,
                Observacao = encomeda.Observacao,
                Data_recebida = encomeda.Data_recebida,
                Data_entrega = encomeda.Data_entrega
            };

            this.encomenda_repositorie.save(encomenda);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EncomendaModel encomeda)
        {
            var encomendaexist = encomenda_repositorie.GetById(id);

            if (encomendaexist == null)
            {
                return NotFound();
            }

            encomendaexist.Codigo = encomeda.Codigo;
            encomendaexist.Nome_morador = encomeda.Nome_morador;
            encomendaexist.Id_morador = encomeda.Id_morador;
            encomendaexist.Observacao = encomeda.Observacao;
            encomendaexist.Data_recebida = encomeda.Data_recebida;
            encomendaexist.Data_entrega = encomeda.Data_entrega;

            encomenda_repositorie.Update(encomendaexist);

            return Ok();
        }

        [HttpPut("{id}/entrega")]
        public IActionResult Put_entrega(int id, [FromBody] EntregaModel dto)
        {
            var encomendaexist = encomenda_repositorie.GetById(id);

            if (encomendaexist == null)
            {
                return NotFound();
            }

            encomendaexist.Data_entrega = dto.Data_entrega;

            encomenda_repositorie.Update(encomendaexist);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            encomenda_repositorie.Delete(id);

            return Ok();
        }
    }
}
