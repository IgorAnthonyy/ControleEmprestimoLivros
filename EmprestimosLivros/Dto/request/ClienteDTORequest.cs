using System.ComponentModel.DataAnnotations;

namespace EmprestimosLivros.Dto
{
    public class ClienteDTORequest
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Endereço deve ter no máximo 100 caracteres.")]
                public string Endereco { get; set; }
        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Cidade deve ter no máximo 100 caracteres.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Bairro deve ter no máximo 100 caracteres.")]
        public string Bairro { get; set; }
    }
}