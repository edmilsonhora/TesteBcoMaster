using Microsoft.AspNetCore.Mvc;
using System;
using TesteBancoMaster.ApplicationService;
using TesteBancoMaster.ApplicationService.Views;

namespace TesteBancoMaster.AppAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotasController : ControllerBase
    {
        IRotaFacade _facade;
        public RotasController()
        {
            _facade = new RotaFacade();
        }

        [HttpPost, Route("Salvar")]
        public IActionResult Salvar([FromBody] RotaView rota)
        {
            try
            {
                _facade.Salvar(rota);
                _facade.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _facade.Rollback();
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet, Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_facade.ObterTodos());
            }
            catch (Exception ex)
            {
                _facade.Rollback();
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet, Route("ObterPor/{id}")]
        public IActionResult ObterPor(int id)
        {
            try
            {
                return Ok(_facade.ObterPor(id));
            }
            catch (Exception ex)
            {
                _facade.Rollback();
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet, Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _facade.Excluir(id);
                _facade.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _facade.Rollback();
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost, Route("CalcularMenorCusto")]
        public IActionResult CalcularMenorCustoPara([FromBody] ViagemView viagem)
        {
            try
            {
                return Ok(_facade.CalcularMenorCustoPara(viagem));
            }
            catch (Exception ex)
            {
                _facade.Rollback();
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
