using API.Dtos;
using API.Errors;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProveedorController : BaseApiController
    {
        private readonly IGenericRepository<Rubro> _RubrosRepo;
        private readonly IGenericRepository<Proveedor> _proveedoresRepo;
        private readonly IMapper _mapper;
        private readonly IProveedorRepository _Proveedor;

        public ProveedorController(IGenericRepository<Proveedor> proveedoresRepo,
            IGenericRepository<Rubro> RubrosRepo, IMapper mapper, IProveedorRepository ProveedorRep)
        {
            _mapper = mapper;
            _proveedoresRepo = proveedoresRepo;
            _RubrosRepo = RubrosRepo;
            _Proveedor = ProveedorRep;
        }


       
        [HttpGet]
        public async Task<ActionResult<Pagination<ProveedorToReturnDto>>> GetProveedores(
            [FromQuery] ProveedorSpecParams proveedorParams)
        {
            var spec = new ProveedoresWithTypesAndRubrosSpecification(proveedorParams);
            var countSpec = new ProveedoresWithFiltersForCountSpecification(proveedorParams);

            var totalItems = await _proveedoresRepo.CountAsync(countSpec);
            var proveedores = await _proveedoresRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<ProveedorToReturnDto>>(proveedores);

            return Ok(new Pagination<ProveedorToReturnDto>(proveedorParams.PageIndex,
                proveedorParams.PageSize, totalItems, data));
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProveedorToReturnDto>> GetProveedor(int id)
        {

            var spec = new ProveedoresWithTypesAndRubrosSpecification(id);

            var proveedor = await _proveedoresRepo.GetEntityWithSpec(spec);

            if (proveedor == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Proveedor, ProveedorToReturnDto>(proveedor);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<int> CreateUpdateProveedorAsync(Proveedor Pro)
        {


            return await _Proveedor.CreateUpdateProveedorAsync(Pro);

        }

    }
}
