using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Infrastructue.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeRepository(StoreContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }




        public int CreateUpdateemployeeAsync(employee emp)
        {
         

           if(emp.Id>0)
            {
                
                _unitOfWork.Repository<employee>().Update(emp);
            }
            else
            {
                // create order
                _unitOfWork.Repository<employee>().Add(emp);
            }

            // save to db
            var result =  _unitOfWork.Complete();
            // return order
            return result.Result;
        }

        public  int DeleteEmployee(employee emp)
        {
             _unitOfWork.Repository<employee>().Delete(emp);

            // save to db
            var result = _unitOfWork.Complete();
            // return order
            return result.Result;
        }

        public async Task<employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
              .Include(p => p.CatCompany)
              .Include(p => p.CatEducation)
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<employee>> GetEmployeesAsync()
        {
            return await _context.Employees
               .Include(p => p.CatCompany)
              .Include(p => p.CatEducation)
               .ToListAsync();
        }
    }
}