using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AT_DanilloLiz.Models
{
    public class Funcionario
    {
        [Key]
        [Display(Name = "Id do Funcionário")]
        public int FuncionarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public String Nome { get; set; }

        public String Telefone { get; set; }

        [Required, EmailAddress]
        public String Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [ForeignKey("Endereco")]
        [Display(Name = "Endereço")]
        public int EnderecoId { get; set; }

        [ForeignKey("Departamento")]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

        [Display(Name = "Endereço")]
        public virtual Endereco? Endereco { get; set; }

        public virtual Departamento? Departamento { get; set; }

    }
}
