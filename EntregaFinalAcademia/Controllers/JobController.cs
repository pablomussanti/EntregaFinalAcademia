﻿using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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



        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Insert(JobDto dto)
        {

            var job = new Job(dto);
            await _unitOfWork.JobRepository.Insert(job);
            await _unitOfWork.Complete();
            return Ok(true);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, JobDto dto)
        {
            var result = await _unitOfWork.JobRepository.Update(new Job(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.JobRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }


    }
}
