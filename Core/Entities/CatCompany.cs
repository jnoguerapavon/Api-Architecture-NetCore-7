using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  class CatCompany : BaseEntity
    {
        public string name { get; set; }
        public bool Estado { get; set; }
    }
}
