using SM.Domaiin.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domaiin.Entities
{
    public class ServicoTecnico
    {
        public int ServicoId { get; set; }
        public Servicos Servico { get; set; }
        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }
    }
}
