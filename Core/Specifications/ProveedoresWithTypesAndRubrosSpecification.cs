using Core.Entities;

namespace Core.Specifications
{
    public class ProveedoresWithTypesAndRubrosSpecification : BaseSpecification<Proveedor>
    {
        public ProveedoresWithTypesAndRubrosSpecification(ProveedorSpecParams proveedorParams)
            : base(x =>
            (string.IsNullOrEmpty(proveedorParams.Search) || x.Name.ToLower().Contains(proveedorParams.Search)) &&
            (!proveedorParams.RubroId.HasValue || x.RubrosId == proveedorParams.RubroId) 
            )
        {
            AddInclude(x => x.Rubros);
            AddOrderBy(x => x.Name);
            ApplyPaging(proveedorParams.PageSize * (proveedorParams.PageIndex - 1),
                proveedorParams.PageSize);

            if (!string.IsNullOrEmpty(proveedorParams.Sort))
            {
                switch (proveedorParams.Sort)
                {
                    case "OrderByBName":
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProveedoresWithTypesAndRubrosSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Rubros);
        }
    }
}