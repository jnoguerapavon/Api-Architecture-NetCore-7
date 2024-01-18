using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Proveedor : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public  string Telefono { get; set; }

        public string  Correo { get; set; }
        public Rubro Rubros { get; set; }

        public int RubrosId { get; set; }   
    }
}
