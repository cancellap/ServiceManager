using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Domaiin.Entities;

namespace SM.Application.DTOs
{
    public class EnderecoSedeDto
    {
        [Required(ErrorMessage = "O Endereço é obrigatório")]
        public Endereco Endereco { get; set; }
    }
}
