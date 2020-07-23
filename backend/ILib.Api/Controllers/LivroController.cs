using ILib.Servicos.Livros;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ILib.Api.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroServico _livroServico;

        public LivroController(ILivroServico livroServico)
        {
            _livroServico = livroServico;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Criar([FromBody] LivroViewModel livroViewModel)
        {
            var livro = await _livroServico.Criar(livroViewModel);

            if (_livroServico.Sucesso())
                return Ok(livro);
           
            return BadRequest(_livroServico.Erros);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Editar([FromBody] LivroViewModel livroViewModel)
        {
            var livro = await _livroServico.Editar(livroViewModel);

            if (_livroServico.Sucesso())
                return Ok(livro);

            return BadRequest(_livroServico.Erros);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            await _livroServico.Remover(id);

            if (_livroServico.Sucesso())
                return Ok("Livro Removido com sucesso");

            return BadRequest(_livroServico.Erros);
        }

        [HttpPut]
        [Route("emprestar")]
        public async Task<IActionResult> Emprestar([FromQuery] int id)
        {
            var livro = await _livroServico.Emprestar(id);

            if (_livroServico.Sucesso())
                return Ok(livro);

            return BadRequest(_livroServico.Erros);
        }

        [HttpPut]
        [Route("devolver")]
        public async Task<IActionResult> Devolver([FromQuery] int id)
        {
            var livro = await _livroServico.Devolver(id);

            if (_livroServico.Sucesso())
                return Ok(livro);

            return BadRequest(_livroServico.Erros);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> SelecionarPorId([FromRoute] int id)
        {
            var livro = await _livroServico.SelecionarPorId(id);

            if (livro != null)
                return Ok(livro);
            if (livro == null)
                return NotFound();

            return BadRequest();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> SelecionarTodos()
        {
            var livros = await _livroServico.SelecionarTodos();

            if (livros != null)
                return Ok(livros);

            return NoContent();
        }

        [HttpGet]
        [Route("disponiveis")]
        public async Task<IActionResult> SelecionarDisponiveis()
        {
            var livros = await _livroServico.SelecionarDisponiveis();

            if (livros != null)
                return Ok(livros);

            return NoContent();
        }
    }
}
