using EmprestimosLivros.Models;
namespace EmprestimosLivros.Repositorios.Interface
{
    public interface IEmprestimoRepositorio
    {
        Task<EmprestimoModel> CriarEmprestimo(EmprestimoModel emprestimo);
        Task<EmprestimoModel> AtualizarEmprestimo(EmprestimoModel emprestimo, int id);
        Task<EmprestimoModel> ObterEmprestimoPorId(int id);
        Task<List<EmprestimoModel>> ObterTodosEmprestimos();
        Task<EmprestimoModel> DeletarEmprestimo(int id);
    }
}