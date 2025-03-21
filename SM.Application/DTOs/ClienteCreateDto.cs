using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.DTOs
{
    public class ClienteCreateDto
    {
        [Required(ErrorMessage = "A Razão social é obrigatória")]
        [StringLength(100, ErrorMessage = "A Razão social não pode exceder 100 caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O nome fantasia é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome fantasia não pode exceder 100 caracteres")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ deve conter 14 dígitos numéricos")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório 2")]
        public EnderecoComplementoCreateDto EnderecoComplementoCreateDto { get; set; }

    }
}
