using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Domaiin.Entities;

namespace SM.Application.DTOs
{
    public class EnderecoSedeDto
    {
        public string Complemento { get; set; }
        public EnderecoDto EnderecoDto { get; set; }


    }
}
