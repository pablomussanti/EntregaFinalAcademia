using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Helpers;
using EntregaFinalAcademia.Infrastructure;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }


        /// <summary>
        ///  Log in User
        /// </summary>
        /// <returns> User Token </returns>
       
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(dto);
            if (userCredentials is null) return Unauthorized("Las credenciales son incorrectas");

            if (userCredentials.Estado == false) return Unauthorized("El usuario ha sido dado de baja");

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UserLoginDto()
            {
                Email = userCredentials.Email,
                Name = userCredentials.Nombre,
                Token = token
            };


            return ResponseFactory.CreateSuccessResponse(200,user);

        }
    }
}
