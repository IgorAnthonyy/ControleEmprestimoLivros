using EmprestimosLivros.Models;

namespace EmprestimosLivros.Repositorios.Interface
{
    public interface ILivroRepositorio
    {
        Task<LivroModel> CriarLivro(LivroModel livro);
        Task<LivroModel> AtualizarLivro(LivroModel livro, int id);
        Task<LivroModel> ObterLivroPorId(int id);
        Task<List<LivroModel>> ObterTodosLivros();
        Task<LivroModel> DeletarLivro(int id);

    }
}