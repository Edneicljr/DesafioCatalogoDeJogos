using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Services;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }



        [HttpGet]
        public async Task<ActionResult<List<JogoInputModel>>> obter() 
        
        {
            var result = await _jogoService.Obter(1, 5);
            return Ok(result);

        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }



        [HttpPut]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, JogoInputModel jogo)
        {
            return Ok();

        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult<List<object>>> AtualizarJogo(Guid idJogo, JogoInputModel jogo)
        {
            return Ok();

        }

        [HttpDelete]

        public async Task<AcceptedResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }


    }
}
