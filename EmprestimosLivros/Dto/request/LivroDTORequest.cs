using System.ComponentModel.DataAnnotations;


namespace EmprestimosLivros.Dto
{
    public class LivroDTORequest
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Autor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Autor deve ter no máximo 100 caracteres.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O campo Editora é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Editora deve ter no máximo 100 caracteres.")]
        public string Editora { get; set; }
    }

}