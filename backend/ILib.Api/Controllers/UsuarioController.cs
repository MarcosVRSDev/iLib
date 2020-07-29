using ILib.Servicos.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ILib.Api.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }


        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioViewModel usuarioViewModel)
        {
            var usuario = await _usuarioServico.CriarUsuario(usuarioViewModel);

            if (usuario != null)
                return Ok(usuario);

            return BadRequest("Não foi possível criar o usuário.");
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var usuarios = await _usuarioServico.SelecionarTodos();

            if (usuarios != null)
                return Ok(usuarios);

            return BadRequest("Não foi possível buscar os usuários.");
        }

    }
}
