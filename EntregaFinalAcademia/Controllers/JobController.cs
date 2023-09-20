using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
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
            await _unitOfWork.JobRepository.Insert(job);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, JobDto dto)
        {
            var result = await _unitOfWork.JobRepository.Update(new Job(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }


        [Authorize(Policy = "Admin")]
        [HttpDelete("Hard/{id}")]
        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.JobRepository.HardDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }


        [Authorize(Policy = "Admin")]
        [HttpDelete("Soft/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.JobRepository.SoftDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }


    }
}
