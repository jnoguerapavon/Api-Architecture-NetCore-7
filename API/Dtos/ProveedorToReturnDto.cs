using Core.Entities;

namespace API.Dtos
{
    public class ProveedorToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }
        public string  Rubro { get; set; }

        public int RubrosId { get; set; }
    }
}
