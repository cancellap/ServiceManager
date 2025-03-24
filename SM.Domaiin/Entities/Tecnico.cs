using SM.Domaiin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domaiin.Entities
{
    public class Tecnico : BaseEntity
    {

        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        [InverseProperty("Tecnico")]
        public EnderecoComplemento? EnderecoComplemento { get; set; }
        public List<ServicoTecnico> servicoTecnicos { get; set; }
        public int ServicosId { get; set; }
    }
}
