using System.ComponentModel.DataAnnotations;

namespace AT_DanilloLiz.Models
{
    public class Departamento
    {
        [Key]
        [Display(Name = "Id do Departamento")]
        public int DepartamentoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Local { get; set; }

        public ICollection<Funcionario>? Funcionarios { get; set; }

    }
}
