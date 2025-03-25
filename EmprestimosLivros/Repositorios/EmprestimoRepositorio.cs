using Microsoft.EntityFrameworkCore;
using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using EmprestimosLivros.Repositorios.Interface;

namespace EmprestimosLivros.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio 
    {
        private readonly EmprestimosLivrosDBContext _dbcontext;
        
        public EmprestimoRepositorio(EmprestimosLivrosDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<EmprestimoModel> CriarEmprestimo(EmprestimoModel emprestimo)
        {
            _dbcontext.Emprestimos.Add(emprestimo);
            await _dbcontext.SaveChangesAsync();

            return await _dbcontext.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(e => e.Id == emprestimo.Id);
        }
        public async Task<EmprestimoModel> AtualizarEmprestimo(EmprestimoModel emprestimo, int id)
        {
            EmprestimoModel emprestimoAtualizado = await ObterEmprestimoPorId(emprestimo.Id);
            if (emprestimoAtualizado == null)
            {
                throw new Exception($"Emprestimo para o ID: {emprestimo.Id} não encontrado");
            }
            emprestimoAtualizado.Id = emprestimo.Id;
            emprestimoAtualizado.LivroId = emprestimo.LivroId;
            emprestimoAtualizado.ClienteId = emprestimo.ClienteId;
            emprestimoAtualizado.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoAtualizado.DataDevolucao = emprestimo.DataDevolucao;

            _dbcontext.Emprestimos.Update(emprestimoAtualizado);
            await _dbcontext.SaveChangesAsync();
            return emprestimoAtualizado;   
        }

        public async Task<EmprestimoModel> ObterEmprestimoPorId(int id)
        {
            return await _dbcontext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EmprestimoModel>> ObterTodosEmprestimos()
        {
            return await _dbcontext.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Cliente)
                .ToListAsync();
        }

        public async Task<EmprestimoModel> DeletarEmprestimo(int id)
        {
            EmprestimoModel emprestimo = await ObterEmprestimoPorId(id);
            if (emprestimo == null)
            {
                throw new Exception($"Emprestimo para o ID: {id} não encontrado");
            }
            _dbcontext.Emprestimos.Remove(emprestimo);
            await _dbcontext.SaveChangesAsync();
            return emprestimo;
        }

    }
}