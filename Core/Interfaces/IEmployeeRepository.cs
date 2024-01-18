using Core.Entities;
using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
     
        int CreateUpdateemployeeAsync(employee emp);

        int DeleteEmployee(employee emp);


         Task<employee> GetEmployeeByIdAsync(int id);
         Task<IReadOnlyList<employee>> GetEmployeesAsync();
      



    }
}
