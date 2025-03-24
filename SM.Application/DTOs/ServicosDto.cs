using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.DTOs
{
    class ServicosDto
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public string Descricao { get; set; }
        public List<Tecnico> Tecnicos { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public bool IsAtivo { get; set; }
    }
}
