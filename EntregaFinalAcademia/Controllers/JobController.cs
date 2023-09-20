using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Infrastructure;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class JobController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetAll()
        {
            var jobs = await _unitOfWork.JobRepository.GetAll();

            return jobs;
        }

        [HttpGet]
        [Route("ListState")]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllState(Boolean EstadoActivo)
        {

                var Jobs = await _unitOfWork.JobRepository.GetAll();
                var listaCompletaJobs = new List<Job>();

                foreach (var job in Jobs)
                {
                    if (EstadoActivo == true && job.Estado == true)
                    {
                        listaCompletaJobs.Add(job);
                    }

                    if (EstadoActivo == false && job.Estado == false)
                    {
                        listaCompletaJobs.Add(job);
                    }
                }
                return listaCompletaJobs;
           
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Job>> GetById(int id)
        {
            var job = await _unitOfWork.JobRepository.GetById(id);

            return job;
        }


        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Insert(JobDto dto)
        {

            var job = new Job(dto);
            var result = await _unitOfWork.JobRepository.Insert(job);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al crear el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Trabajo creado con exito");
            }
        }


        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, JobDto dto)
        {
            var result = await _unitOfWork.JobRepository.Update(new Job(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al modificar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo modificado con exito");
            }
        }


        [Authorize(Policy = "Admin")]
        [HttpDelete("Hard/{id}")]
        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.JobRepository.HardDelete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo eliminado con exito");
            }
        }


        [Authorize(Policy = "Admin")]
        [HttpDelete("Soft/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.JobRepository.SoftDelete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo eliminado con exito");
            }
        }


    }
}
