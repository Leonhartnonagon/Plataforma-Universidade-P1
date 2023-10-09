using DDD.Domain.TiContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        readonly ITecnicoRepository _tecnicoRepository;

        public TecnicoController(ITecnicoRepository tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
        }

        [HttpGet]
        public ActionResult<List<Tecnico>> Get()
        {
            return Ok(_tecnicoRepository.GetTecnicos());
        }

        [HttpGet("{id}")]
        public ActionResult<Tecnico> GetById(int id)
        {
            return Ok(_tecnicoRepository.GetTecnicoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Tecnico> CreateTecnico(Tecnico tecnico)
        {
            if (tecnico.Nome.Length < 3 || tecnico.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _tecnicoRepository.InsertTecnico(tecnico);
            return CreatedAtAction(nameof(GetById), new { id = tecnico.UserId }, tecnico);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Tecnico tecnico)
        {
            try
            {
                if (tecnico == null)
                    return NotFound();

                _tecnicoRepository.UpdateTecnico(tecnico);
                return Ok("Técnico Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        [HttpDelete()]
        public ActionResult Delete([FromBody] Tecnico tecnico)
        {
            try
            {
                if (tecnico == null)
                    return NotFound();

                _tecnicoRepository.DeleteTecnico(tecnico);
                return Ok("Técnico Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}

