using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            var services = await _unitOfWork.ServiceRepository.GetAll();

            return services;
        }

        [HttpGet]
        [Route("ListState")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllState(Boolean EstadoActivo)
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
            return listaCompletaServices;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Service>> GetById(int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetById(id);

            return service;
        }



        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Insert(ServiceDto dto)
        {

            var service = new Service(dto);
            await _unitOfWork.ServiceRepository.Insert(service);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, ServiceDto dto)
        {
            var result = await _unitOfWork.ServiceRepository.Update(new Service(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("Hard/{id}")]

        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServiceRepository.HardDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("Soft/{id}")]

        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServiceRepository.SoftDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}
