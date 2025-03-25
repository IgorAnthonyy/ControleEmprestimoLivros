using Microsoft.EntityFrameworkCore;
using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using EmprestimosLivros.Repositorios.Interface;

namespace EmprestimosLivros.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly EmprestimosLivrosDBContext _dbcontext;
        public ClienteRepositorio(EmprestimosLivrosDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<ClienteModel> CriarCliente(ClienteModel cliente)
        {
            _dbcontext.Clientes.Add(cliente);
            await _dbcontext.SaveChangesAsync();
            return cliente;
        }
        public async Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id)
        {
            ClienteModel clienteAtualizado = await ObterClientePorId(cliente.Id);
            if (clienteAtualizado == null)
            {
                throw new Exception($"Cliente para o ID: {id} não encontrado");
            }
            clienteAtualizado.Nome = cliente.Nome;
            clienteAtualizado.Email = cliente.Email;
            clienteAtualizado.Endereco = cliente.Endereco;
            clienteAtualizado.Cidade = cliente.Cidade;
            clienteAtualizado.Bairro = cliente.Bairro;

            _dbcontext.Clientes.Update(clienteAtualizado);
            await _dbcontext.SaveChangesAsync();
            return clienteAtualizado;
        }
        public async Task<ClienteModel> ObterClientePorId(int id)
        {
            return await _dbcontext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<ClienteModel>> ObterTodosClientes()
        {
            return await _dbcontext.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> DeletarCliente(int id)
        {
            ClienteModel cliente = await ObterClientePorId(id);
            if (cliente == null)
            {
                throw new Exception($"Cliente para o ID: {id} não encontrado");
            }
            _dbcontext.Clientes.Remove(cliente);
            await _dbcontext.SaveChangesAsync();
            return cliente;
        }
        
    }
}