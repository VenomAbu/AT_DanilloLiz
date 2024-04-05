using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AT_DanilloLiz.Models
{
    public class Endereco
    {
        [Key]
        [Display(Name = "Id do Endereço")]
        public int EnderecoId { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Cidade { get; set; }

        public virtual Funcionario? Funcionario { get; set; }
    }
}
