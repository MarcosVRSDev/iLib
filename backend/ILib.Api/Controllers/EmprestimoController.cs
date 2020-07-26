using ILib.Servicos.Emprestimos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ILib.Api.Controllers
{
    [ApiController]
    [Route("api/emprestimos")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoServico _emprestimoServico;

        public EmprestimoController(IEmprestimoServico emprestimoServico)
        {
            _emprestimoServico = emprestimoServico;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> SelecionaTodos()
        {
            return Ok(await _emprestimoServico.SelecionarTodos());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> SeleionarPorId(int id)
        {
            return Ok(await _emprestimoServico.SelecionarPorId(id));
        }

        [HttpGet]
        [Route("status/{id:int}")]
        public async Task<IActionResult> SelecionarPorStatus(int id)
        {
            var emprestimos = await _emprestimoServico.SelecionarPorStatus(id);
            if (_emprestimoServico.Sucesso())
            {
                return Ok(emprestimos);
            }
            return BadRequest(_emprestimoServico.Erros);
        }

        [HttpGet]
        [Route("livro/{id:int}")]
        public async Task<IActionResult> SelecionarPorLivroIdEmprestado(int id)
        {
            return Ok(await _emprestimoServico.SelecionarPorLivroEmprestado(id));

        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Criar([FromBody] EmprestimoViewModel emprestimoViewModel)
        {
            var emprestimo = await _emprestimoServico.Criar(emprestimoViewModel);
            if (_emprestimoServico.Sucesso())
            {
                return Ok(emprestimo);
            }
            return BadRequest(_emprestimoServico.Erros);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Editar([FromBody] EmprestimoViewModel emprestimoViewModel)
        {
            var emprestimo = await _emprestimoServico.Editar(emprestimoViewModel);
            if (_emprestimoServico.Sucesso())
            {
                return Ok(emprestimo);
            }
            return BadRequest(_emprestimoServico.Erros);
        }

        [HttpPut]
        [Route("cancelar/{id:int}")]
        public async Task<IActionResult> CancelarEmprestimo(int id)
        {
            var emprestimo = await _emprestimoServico.CancelaEmprestimo(new EmprestimoViewModel { Id = id});
            if (_emprestimoServico.Sucesso())
            {
                return Ok(emprestimo);
            }
            return BadRequest(_emprestimoServico.Erros);
        }

        [HttpPut]
        [Route("confirmar/{id:int}")]
        public async Task<IActionResult> ConfirmarEmprestimo(int id)
        {
            var emprestimo = await _emprestimoServico.ConfirmaEmprestimo(new EmprestimoViewModel { Id = id });
            if (_emprestimoServico.Sucesso())
            {
                return Ok(emprestimo);
            }
            return BadRequest(_emprestimoServico.Erros);
        }

        [HttpPut]
        [Route("devolver/{id:int}")]
        public async Task<IActionResult> RealizaDevolucao(int id)
        {
            var emprestimo = await _emprestimoServico.RealizaDevolucao(new EmprestimoViewModel { Id = id });
            if (_emprestimoServico.Sucesso())
            {
                return Ok(emprestimo);
            }
            return BadRequest(_emprestimoServico.Erros);
        }


    }
}
