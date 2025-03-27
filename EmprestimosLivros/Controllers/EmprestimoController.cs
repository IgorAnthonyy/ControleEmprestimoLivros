using EmprestimosLivros.Models;
using EmprestimosLivros.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;
using EmprestimosLivros.Dto;
using AutoMapper;
using EmprestimosLivros.Email;

namespace EmprestimosLivros.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EmprestimoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly EmailService _emailService;
        public EmprestimoController(IEmprestimoRepositorio emprestimoRepositorio, IMapper mapper , EmailService emailService)
        {
            _mapper = mapper;
            _emprestimoRepositorio = emprestimoRepositorio;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult<EmprestimoDTOResponse>> CadastrarEmprestimo([FromBody] EmprestimoDTORequest emprestimo)
        {
            EmprestimoModel emprestimoModel = _mapper.Map<EmprestimoModel>(emprestimo);

            EmprestimoModel emprestimoCriado = await _emprestimoRepositorio.CriarEmprestimo(emprestimoModel);

            EmprestimoDTOResponse emprestimoResponse = _mapper.Map<EmprestimoDTOResponse>(emprestimoCriado);

            List<string> bodyEmail = new List<string>();
            bodyEmail.Add(emprestimoModel.Cliente.Nome);
            bodyEmail.Add(emprestimoModel.Livro.Nome);
            bodyEmail.Add(emprestimoModel.DataEmprestimo.ToString());
            bodyEmail.Add(emprestimoModel.DataDevolucao.ToString());
            await _emailService.EnviarEmailAsync(emprestimoModel.Cliente.Email, "Confirmação de Empréstimo", bodyEmail);

            return CreatedAtAction(nameof(CadastrarEmprestimo), new { id = emprestimoResponse.Id }, emprestimoResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmprestimoDTOResponse>>> ListarEmprestimos()
        {
            List<EmprestimoModel> emprestimos = await _emprestimoRepositorio.ObterTodosEmprestimos();

            List<EmprestimoDTOResponse> emprestimosResponse = _mapper.Map<List<EmprestimoDTOResponse>>(emprestimos);

            return Ok(emprestimosResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmprestimoDTOResponse>> ObterEmprestimoPorId([FromRoute] int id)
        {
            EmprestimoModel emprestimo = await _emprestimoRepositorio.ObterEmprestimoPorId(id);

            if (emprestimo == null)
            {
                return NotFound("Emprestimo não encontrado");
            }

            EmprestimoDTOResponse emprestimoResponse = _mapper.Map<EmprestimoDTOResponse>(emprestimo);

            return Ok(emprestimoResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmprestimoDTOResponse>> AtualizarEmprestimo([FromRoute] int id, [FromBody] EmprestimoDTORequest emprestimo)
        {
            EmprestimoModel emprestimoModel = _mapper.Map<EmprestimoModel>(emprestimo);

            emprestimoModel.Id = id;

            await _emprestimoRepositorio.AtualizarEmprestimo(emprestimoModel, id);

            EmprestimoDTOResponse emprestimoResponse = _mapper.Map<EmprestimoDTOResponse>(emprestimoModel);
            return Ok(emprestimoResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarEmprestimo([FromRoute] int id)
        {
            await _emprestimoRepositorio.DeletarEmprestimo(id);

            return NoContent();
        }

    }
}