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


        [HttpGet]
        [Route("ListState")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllState(Boolean EstadoActivo)
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            var listaCompletaUsers = new List<User>();

            foreach (var usr in users)
            {
                if (EstadoActivo == true && usr.Estado == true)
                {
                    listaCompletaUsers.Add(usr);
                }

                if (EstadoActivo == false && usr.Estado == false)
                {
                    listaCompletaUsers.Add(usr);
                }
            }
            return listaCompletaUsers;
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            return user;
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

        [HttpDelete("Hard/{id}")]

        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.HardDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("Soft/{id}")]

        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.SoftDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
