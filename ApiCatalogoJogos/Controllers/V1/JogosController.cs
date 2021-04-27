using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid id)
        {
            var jogo = await _jogoService.Obter(id);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        /// <summary>
        /// Post para inserir novo jogo
        /// </summary>
        /// <param name="jogoModel"> Model do jogo</param>
        /// <returns>O jogo cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid id, [FromBody] JogoInputModel jogoModel)
        {
            try
            {
                await _jogoService.Atualizar(id, jogoModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{id:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid id, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(id, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid id)
        {
            try
            {
                await _jogoService.Remover(id);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
