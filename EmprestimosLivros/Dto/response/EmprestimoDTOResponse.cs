namespace EmprestimosLivros.Dto 
{
    public class EmprestimoDTOResponse 
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public LivroDTO Livro { get; set; }
        public int ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }   
    }
    public class LivroDTO
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
    }

    public class ClienteDTO
    {
        public string Nome { get; set; }

    }
}