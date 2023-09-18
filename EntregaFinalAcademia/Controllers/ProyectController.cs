using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProyectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyect>>> GetAll()
        {
            var proyects = await _unitOfWork.ProyectRepository.GetAll();

            return proyects;
        }



        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Insert(ProyectDto dto)
        {

            var proyect = new Proyect(dto);
            await _unitOfWork.ProyectRepository.Insert(proyect);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, ProyectDto dto)
        {
            var result = await _unitOfWork.ProyectRepository.Update(new Proyect(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
