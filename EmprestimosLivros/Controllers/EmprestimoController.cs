using EmprestimosLivros.Models;
using EmprestimosLivros.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;
using EmprestimosLivros.Dto;
using AutoMapper;

namespace EmprestimosLivros.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EmprestimoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public EmprestimoController(IEmprestimoRepositorio emprestimoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<EmprestimoDTOResponse>> CadastrarEmprestimo([FromBody] EmprestimoDTORequest emprestimo)
        {
            EmprestimoModel emprestimoModel = _mapper.Map<EmprestimoModel>(emprestimo);

            EmprestimoModel emprestimoCriado = await _emprestimoRepositorio.CriarEmprestimo(emprestimoModel);

            EmprestimoDTOResponse emprestimoResponse = _mapper.Map<EmprestimoDTOResponse>(emprestimoCriado);

            return CreatedAtAction(nameof(CadastrarEmprestimo), new { id = emprestimoResponse.Id }, emprestimoResponse);
        }

    }
}