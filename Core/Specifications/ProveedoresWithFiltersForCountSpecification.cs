using Core.Entities;

namespace Core.Specifications
{
    public class ProveedoresWithFiltersForCountSpecification : BaseSpecification<Proveedor>
    {
        public ProveedoresWithFiltersForCountSpecification(ProveedorSpecParams proveedorParams) : base(x =>
            (string.IsNullOrEmpty(proveedorParams.Search) || x.Name.ToLower().Contains(proveedorParams.Search)) &&
            (!proveedorParams.RubroId.HasValue || x.RubrosId == proveedorParams.RubroId))
        {

        }
    }
}