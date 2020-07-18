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
            if (livro != null)
                return Ok(livro);
            return BadRequest("Não foi possível criar o livro");
        }
    }
}
