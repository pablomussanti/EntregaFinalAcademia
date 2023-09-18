using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll();

            return users;
        }



        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {

            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, RegisterDto dto)
        {
            var result = await _unitOfWork.UserRepository.Update(new User(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
