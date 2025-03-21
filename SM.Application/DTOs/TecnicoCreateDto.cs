using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.DTOs
{
    public class TecnicoCreateDto
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 14 dígitos numéricos")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Endereço é obrigatórioq")]
        public EnderecoComplementoCreateDto EnderecoComplementoCreateDto { get; set; }
    }
}
