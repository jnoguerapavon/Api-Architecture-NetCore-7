using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
    public class employeesController : BaseApiController
    {
        private readonly IGenericRepository<employee> _employeeRepo;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _Employee;
        private readonly IGenericRepository<CatEducation> _Education;
        private readonly IGenericRepository<CatCompany> _Company;

        public employeesController(IGenericRepository<employee> empooyeesRepo, IMapper mapper, IEmployeeRepository _EmployeeRepo, IGenericRepository<CatEducation> EducationRepo, IGenericRepository<CatCompany> CompanyRepo)
        {
            _mapper = mapper;
            _employeeRepo = empooyeesRepo;
            _Employee = _EmployeeRepo;
            _Company = CompanyRepo;
            _Education = EducationRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<employee>>> GetEmployees()
        {
            var Employ =await  _Employee.GetEmployeesAsync();

            var data = _mapper.Map<IReadOnlyList<EmployeetoReturnDto>>(Employ);

            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<employee>>> GetEmployeeId(int Id)
        {
            var Employ =await  _Employee.GetEmployeeByIdAsync(Id);

            var data = _mapper.Map<EmployeetoReturnDto>(Employ);

            return Ok(data);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public int UpdateEmployeeAsync(int id,employee emp)
        {
            try
            {
             emp.Id = id;
             _Employee.CreateUpdateemployeeAsync(emp);
            }
            catch (Exception)
            {

                throw;
            }

            return 1;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public int AddEmployeeAsync(employee emp)
        {
            try
            {
                _Employee.CreateUpdateemployeeAsync(emp);
            }
            catch (Exception)
            {

                throw;
            }

            return 1;

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public int deleteEmployeeAsync(int id)
        {
            try
            {
                var Employee = _employeeRepo.GetByIdAsync(id);


                _Employee.DeleteEmployee(Employee.Result);
            }
            catch (Exception)
            {

                throw;
            }

            return 1;

        }



       
        [HttpGet("Education")]
        public async Task<ActionResult<IReadOnlyList<CatEducation>>> GetEducations()
        {
            return Ok(await _Education.ListAllAsync());
        }

    
        [HttpGet("Company")]
        public async Task<ActionResult<IReadOnlyList<CatCompany>>> GetCompanies()
        {
            return Ok(await _Company.ListAllAsync());
        }


    }
}
