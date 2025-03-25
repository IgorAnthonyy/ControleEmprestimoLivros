using Microsoft.EntityFrameworkCore;
using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using EmprestimosLivros.Repositorios.Interface;

namespace EmprestimosLivros.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly EmprestimosLivrosDBContext _dbcontext;
        public LivroRepositorio(EmprestimosLivrosDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<LivroModel> CriarLivro(LivroModel livro)
        {
           await _dbcontext.Livros.AddAsync(livro);
           await  _dbcontext.SaveChangesAsync();
            return livro;
        }
        public async Task<LivroModel> AtualizarLivro(LivroModel livro, int id)
        {
            LivroModel livroAtualizado = await ObterLivroPorId(livro.Id);
            if (livroAtualizado == null)
            {
                 throw new Exception($"Livro para o ID: {id} não encontrado");
            }
            livroAtualizado.Nome = livro.Nome;
            livroAtualizado.Autor = livro.Autor;
            livroAtualizado.Editora = livro.Editora;

            _dbcontext.Livros.Update(livroAtualizado);
            await _dbcontext.SaveChangesAsync();
            return livroAtualizado;
        }
        public async Task<LivroModel> ObterLivroPorId(int id)
        {
            return await _dbcontext.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<LivroModel>> ObterTodosLivros()
        {
            return await _dbcontext.Livros.ToListAsync();
        }
        public async Task<LivroModel> DeletarLivro(int id)
        {
            LivroModel livro = await ObterLivroPorId(id);
            if (livro == null)
            {
                throw new Exception($"Livro para o ID: {id} não encontrado");
            }
            _dbcontext.Livros.Remove(livro);
            await _dbcontext.SaveChangesAsync();
            return livro;
        }
    }
}