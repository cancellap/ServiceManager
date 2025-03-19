using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.DTOs
{
    public class EnderecoSedeCreateDto
    {
        [Required(ErrorMessage = "O Endereço é obrigatório")]
        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "O complemento é obrigatório")]
        public string Complemento { get; set; }
    }
}
