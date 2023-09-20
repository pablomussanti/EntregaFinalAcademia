using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Helpers;
using EntregaFinalAcademia.Infrastructure;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Get All Users
        /// </summary>
        /// <returns> List of Users </returns>

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll();

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateUsers = PaginateHelper.Paginate(users, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
        }


        /// <summary>
        ///  Get All Users by state
        /// </summary>
        /// <returns> List of Users </returns>


        [Authorize]
        [HttpGet]
        [Route("ListState")]
        public async Task<IActionResult> GetAllState(Boolean EstadoActivo)
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

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateUsers = PaginateHelper.Paginate(listaCompletaUsers, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
        }



        /// <summary>
        ///  Get a User by ID
        /// </summary>
        /// <returns> A User </returns>



        [Authorize]
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            return ResponseFactory.CreateSuccessResponse(200, user);
        }



        /// <summary>
        ///  Create a User
        /// </summary>
        /// <returns> Confirm state of request </returns>




        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {

            if (await _unitOfWork.UserRepository.UserEx(dto.Email)) return Ok($"Ya existe un usuario registrado con el mail:{dto.Email}");
            var user = new User(dto);
            var result = await _unitOfWork.UserRepository.Insert(user);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al crear el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Usuario creado con exito");
            }

        }



        /// <summary>
        ///  Update a User
        /// </summary>
        /// <returns> Confirm state of request </returns>




        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, RegisterDto dto)
        {
            var result = await _unitOfWork.UserRepository.Update(new User(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al modificar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Usuario modificado con exito");
            }
        }



        /// <summary>
        ///  Delete a User
        /// </summary>
        /// <returns> Confirm state of request </returns>




        [Authorize(Policy = "Admin")]
        [HttpDelete("Hard/{id}")]

        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.HardDelete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Usuario eliminado con exito");
            }
        }



        /// <summary>
        ///  Delete a User by state
        /// </summary>
        /// <returns> Confirm state of request </returns>



        [Authorize(Policy = "Admin")]
        [HttpDelete("Soft/{id}")]

        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.SoftDelete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Usuario eliminado con exito");
            }
        }
    }
}
