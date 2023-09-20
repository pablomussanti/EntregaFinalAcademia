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
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _unitOfWork.ServiceRepository.GetAll();

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServices = PaginateHelper.Paginate(services, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateServices);
        }

        [HttpGet]
        [Route("ListState")]
        public async Task<IActionResult> GetAllState(Boolean EstadoActivo)
        {
            var services = await _unitOfWork.ServiceRepository.GetAll();
            var listaCompletaServices = new List<Service>();

            foreach (var srv in services)
            {
                if (EstadoActivo == true && srv.estado == true)
                {
                    listaCompletaServices.Add(srv);
                }

                if (EstadoActivo == false && srv.estado == false)
                {
                    listaCompletaServices.Add(srv);
                }
            }

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServices = PaginateHelper.Paginate(listaCompletaServices, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateServices);

        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetById(id);

            return ResponseFactory.CreateSuccessResponse(200, service);
        }


        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Insert(ServiceDto dto)
        {

            var service = new Service(dto);
            var result = await _unitOfWork.ServiceRepository.Insert(service);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al crear el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Servicio creado con exito");
            }

        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, ServiceDto dto)
        {
            var result = await _unitOfWork.ServiceRepository.Update(new Service(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al modificar el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Servicio modificado con exito");
            }

        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("Hard/{id}")]

        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServiceRepository.HardDelete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Servicio eliminado con exito");
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("Soft/{id}")]

        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServiceRepository.SoftDelete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Servicio eliminado con exito");
            }

        }

    }
}
