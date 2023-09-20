using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var Roles = await _unitOfWork.RoleRepository.GetAll();

            return Roles;
        }


        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> Insert(RoleDto dto)
        {

            var Role = new Role(dto);
            await _unitOfWork.RoleRepository.Insert(Role);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, RoleDto dto)
        {
            var result = await _unitOfWork.RoleRepository.Update(new Role(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RoleRepository.HardDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}
