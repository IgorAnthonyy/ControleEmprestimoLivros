namespace EmprestimosLivros.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }

        public virtual LivroModel Livro { get; set; }
        public virtual ClienteModel Cliente { get; set; }
    }
}