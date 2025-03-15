using SM.Domaiin.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domaiin.Entities.Base
{
    public class BaseEntity : IEntityLocal
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public  DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
