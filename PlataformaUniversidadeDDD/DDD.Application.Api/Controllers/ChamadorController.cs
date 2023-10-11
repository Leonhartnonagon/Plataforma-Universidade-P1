using DDD.Domain.TiContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    public class ChamadorController : Controller
    {
        readonly IChamadorRepository _chamadorRepository;

        public ChamadorController(IChamadorRepository chamadorRepository)
        {
            _chamadorRepository = chamadorRepository;
        }

        [HttpGet("chamador/")]
        public ActionResult<List<Chamador>> Get()
        {
            return Ok(_chamadorRepository.GetChamadores());
        }

        [HttpGet("chamador/{id}")]
        public ActionResult<Chamador> GetChamadorById(int id)
        {
            return Ok(_chamadorRepository.GetChamadorById(id));
        }

        [HttpPost("chamador/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Chamador> CreateChamador(Chamador chamador)
        {
            if (chamador.Nome.Length < 3 || chamador.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _chamadorRepository.InsertChamador(chamador);
            return CreatedAtAction(nameof(GetChamadorById), new { id = chamador.UserId }, chamador);
        }

        [HttpPut("chamador/")]
        public ActionResult Put([FromBody] Chamador chamador)
        {
            try
            {
                if (chamador == null)
                    return NotFound();

                _chamadorRepository.UpdateChamador(chamador);
                return Ok("Chamador Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("chamador/")]
        public ActionResult Delete([FromBody] Chamador chamador)
        {
            try
            {
                if (chamador == null)
                    return NotFound();

                _chamadorRepository.DeleteChamador(chamador);
                return Ok("Chamador Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
    