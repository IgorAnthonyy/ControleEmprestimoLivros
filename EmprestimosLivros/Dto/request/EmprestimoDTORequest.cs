namespace EmprestimosLivros.Dto 
{
    public class EmprestimoDTORequest
    {
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }

    }
}