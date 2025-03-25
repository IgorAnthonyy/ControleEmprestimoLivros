using AutoMapper;
using EmprestimosLivros.Dto;
using EmprestimosLivros.Models;
using EmprestimosLivros.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;


namespace EmprestimosLivros.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IMapper _mapper;

        public LivrosController(ILivroRepositorio livroRepositorio, IMapper mapper)
        {
            _livroRepositorio = livroRepositorio;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<LivroDTOResponse>> CadastrarLivro([FromBody] LivroDTORequest livroDto)
        {
            LivroModel livroModel = _mapper.Map<LivroModel>(livroDto);
            LivroModel livroCriado = await _livroRepositorio.CriarLivro(livroModel);
            LivroDTOResponse livroResponse = _mapper.Map<LivroDTOResponse>(livroCriado);
            return CreatedAtAction(nameof(CadastrarLivro), new { id = livroResponse.Id }, livroResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LivroDTOResponse>> AtualizarLivro(int id, [FromBody] LivroDTORequest livroDto)
        {
            LivroModel livroModel = _mapper.Map<LivroModel>(livroDto);
            livroModel.Id = id;
            LivroModel livroAtualizado = await _livroRepositorio.AtualizarLivro(livroModel, id);
            LivroDTOResponse livroResponse = _mapper.Map<LivroDTOResponse>(livroAtualizado);
            return Ok(livroResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDTOResponse>> ObterLivroPorId(int id)
        {
            LivroModel livro = await _livroRepositorio.ObterLivroPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            LivroDTOResponse livroResponse = _mapper.Map<LivroDTOResponse>(livro);
            return Ok(livroResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroDTOResponse>>> ObterTodosLivros()
        {
            List<LivroModel> livros = await _livroRepositorio.ObterTodosLivros();
            List<LivroDTOResponse> livrosResponse = _mapper.Map<List<LivroDTOResponse>>(livros);
            return Ok(livrosResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarLivro(int id)
        {
            await _livroRepositorio.DeletarLivro(id);
            return NoContent();
        }
    }
}
