using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domaiin.Entities.Base
{
    class BaseEntities
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateAt { get; set; }
        public  DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
