using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Infrastructue.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly StoreContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProveedorRepository(StoreContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }




        public async Task<IReadOnlyList<Rubro>> GetRubrosAsync()
        {
            return await _context.Rubros.ToListAsync();
        }

        public async Task<Proveedor> GetProveedorByIdAsync(int id)
        {
            return await _context.Proveedores
                .Include(p => p.Rubros)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Proveedor>> GetProveedoresAsync()
        {
            return await _context.Proveedores
                .Include(p => p.Rubros)
                .ToListAsync();
        }

        public async Task<int> CreateUpdateProveedorAsync(Proveedor Pro)
        {
         

           if(Pro.Id>0)
            {
                
                _unitOfWork.Repository<Proveedor>().Update(Pro);
            }
            else
            {
                // create order
                _unitOfWork.Repository<Proveedor>().Add(Pro);
            }

            // save to db
            var result = await _unitOfWork.Complete();
            // return order
            return result;
        }
    }
}