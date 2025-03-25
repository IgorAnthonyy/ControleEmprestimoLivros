using EmprestimosLivros.Models;

namespace EmprestimosLivros.Repositorios.Interface
{
    public interface IClienteRepositorio
    {
        Task<ClienteModel> CriarCliente(ClienteModel cliente);
        Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id);
        Task<ClienteModel> ObterClientePorId(int id);
        Task<List<ClienteModel>> ObterTodosClientes();
        Task<ClienteModel> DeletarCliente(int id);
    }
}