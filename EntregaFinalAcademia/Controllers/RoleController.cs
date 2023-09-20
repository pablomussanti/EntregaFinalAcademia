using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Helpers;
using EntregaFinalAcademia.Infrastructure;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Get All Roles
        /// </summary>
        /// <returns>List of Roles</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _unitOfWork.RoleRepository.GetAll();
            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateRoles = PaginateHelper.Paginate(roles, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateRoles);
        }

        /// <summary>
        ///  Create a new Role
        /// </summary>
        /// <returns> Confirm state of request </returns>

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> Insert(RoleDto dto)
        {

            var Role = new Role(dto);
            var result = await _unitOfWork.RoleRepository.Insert(Role);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al crear el rol");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Rol creado con exito");
            }
        }

        /// <summary>
        ///  Update a role 
        /// </summary>
        /// <returns> Confirm state of request </returns>

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, RoleDto dto)
        {
            var result = await _unitOfWork.RoleRepository.Update(new Role(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al modificar el rol");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Rol modificado con exito");
            }
        }

        /// <summary>
        ///  Delete a Role
        /// </summary>
        /// <returns> Confirm state of request </returns>


        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RoleRepository.HardDelete(id);


            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el rol");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Rol eliminado con exito");
            }
        }

    }
}
