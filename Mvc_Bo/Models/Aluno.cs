using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Bo.Models
{
    public class Aluno
    {
        [BindRequired]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome deve ter mais de 5 e menos de 50")]
        [Display(Name = "Informe o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sexo é obrigatório")]
        [Display(Name = "Informe o sexo do cliente")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento deve ser informada")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }


    }
}
