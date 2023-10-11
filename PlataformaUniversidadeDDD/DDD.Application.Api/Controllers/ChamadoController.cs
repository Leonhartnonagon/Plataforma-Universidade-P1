using DDD.Domain.TiContext;
using Newtonsoft.Json;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace DDD.Application.Api.Controllers
{
    public class ChamadoController : Controller
    {
        readonly IChamadoRepository _chamadoRepository;

        public ChamadoController(IChamadoRepository chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
        }

        [HttpGet("chamado/")]
        public ActionResult<List<Chamado>> Get()
        {
            return Ok(_chamadoRepository.GetChamados());
        }

        [HttpGet("chamado/{id}")]
        public ActionResult<Chamado> GetById(int id)
        {
            return Ok(_chamadoRepository.GetChamadoById(id));
        }

        [HttpPost("chamado/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Chamado> CreateChamado([FromBody]Chamado chamado)
        {
            _chamadoRepository.InsertChamado(chamado);
            return CreatedAtAction(nameof(GetById), new { id = chamado.Id }, chamado);
        }

        [HttpPut("chamado/")]
        public ActionResult Put([FromBody] Chamado chamado)
        {
            try
            {
                if (chamado == null)
                    return NotFound();

                _chamadoRepository.UpdateChamado(chamado);
                return Ok("Chamdado Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

    //    [HttpPatch("{id}")]
    //    public IActionResult JsonPatchWithModelState(
    //[FromBody] JsonPatchDocument<Chamado> patchDoc)
    //    {
    //        if (patchDoc != null)
    //        {
    //            var chamado = _chamadoRepository.AssignTecnico();

    //            patchDoc.ApplyTo(chamado, ModelState);

    //            if (!ModelState.IsValid)
    //            {
    //                return BadRequest(ModelState);
    //            }

    //            return new ObjectResult(customer);
    //        }
    //        else
    //        {
    //            return BadRequest(ModelState);
    //        }
    //    }

        [HttpDelete("chamado/")]
        public ActionResult Delete([FromBody] Chamado chamado)
        {
            try
            {
                if (chamado == null)
                    return NotFound();

                _chamadoRepository.DeleteChamado(chamado);
                return Ok("Chamado Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}

