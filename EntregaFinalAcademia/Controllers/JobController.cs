using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Helpers;
using EntregaFinalAcademia.Infrastructure;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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


        /// <summary>
        ///  Get all Jobs without state
        /// </summary>
        /// <returns> All jobs </returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _unitOfWork.JobRepository.GetAll();

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateJobs = PaginateHelper.Paginate(jobs, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateJobs);

        }

        /// <summary>
        ///  Get all Jobs by state 
        /// </summary>
        /// <returns> List of jobs </returns>

        [HttpGet]
        [Route("ListState")]
        public async Task<IActionResult> GetAllState(Boolean EstadoActivo)
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

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateJobs = PaginateHelper.Paginate(listaCompletaJobs, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateJobs);
           
        }

        /// <summary>
        ///  Get a job by id
        /// </summary>
        /// <returns> A Job </returns>

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _unitOfWork.JobRepository.GetById(id);

            return ResponseFactory.CreateSuccessResponse(200, job);
        }

        /// <summary>
        ///  Create a Job
        /// </summary>
        /// <returns> Confirm state of request </returns>

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


        /// <summary>
        ///  Update a Job
        /// </summary>
        /// <returns> Confirm state of request </returns>

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

        /// <summary>
        ///  Delete a job 
        /// </summary>
        /// <returns> Confirm state of request </returns>

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

        /// <summary>
        ///  Delete a job by state
        /// </summary>
        /// <returns> Confirm state of request </returns>

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
