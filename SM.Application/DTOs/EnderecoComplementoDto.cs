using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SM.Domaiin.Entities;

namespace SM.Application.DTOs
{
    public class EnderecoComplementoDto
    {
        public string Complemento { get; set; }
        public EnderecoDto EnderecoDto { get; set; }
        [JsonIgnore]
        public ClienteDto? ClienteDto { get; set; }
        [JsonIgnore]
        public TecnicoDto? TecnicoDto { get; set; }
    }
}
