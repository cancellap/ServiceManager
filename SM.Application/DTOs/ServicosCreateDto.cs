using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.DTOs
{
    class ServicosCreateDto
    {
        public string Descricao { get; set; }
        public List<int> TecnicosIds { get; set; }
    }
}
