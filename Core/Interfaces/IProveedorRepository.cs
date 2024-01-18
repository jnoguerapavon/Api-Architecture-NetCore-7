using Core.Entities;
using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProveedorRepository
    {
        Task<Proveedor> GetProveedorByIdAsync(int id);
        Task<IReadOnlyList<Proveedor>> GetProveedoresAsync();
        Task<IReadOnlyList<Rubro>> GetRubrosAsync();

        Task<int> CreateUpdateProveedorAsync(Proveedor Pro);

    }
}
