using SM.Domaiin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domaiin.Entities
{
    public class EnderecoSede : BaseEntity
    {
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public String Complemento { get; set; }
    }
}
