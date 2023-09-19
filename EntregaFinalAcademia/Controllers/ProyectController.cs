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


        [HttpGet]
        [Route("ListState")]
        public async Task<ActionResult<IEnumerable<Proyect>>> GetAllState(Proyect.EstadoProyecto EstadoProyecto, Boolean EstadoActivo)
        {
            var proyects = await _unitOfWork.ProyectRepository.GetAll();
            var listaCompletaProyects = new List<Proyect>();

            foreach (var pr in proyects)
            {
                if (EstadoActivo == true && pr.EstadoActivo == true)
                {
                    if (pr.Estado == EstadoProyecto || EstadoProyecto == 0 )
                    {
                        listaCompletaProyects.Add(pr);
                    }

                }

                if (EstadoActivo == false && pr.EstadoActivo == false)
                {
                    if (pr.Estado == EstadoProyecto || EstadoProyecto == 0)
                    {
                        listaCompletaProyects.Add(pr);
                    }
                }

            }
            return listaCompletaProyects;
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Proyect>> GetById(int id)
        {
            var proyect = await _unitOfWork.ProyectRepository.GetById(id);

            return proyect;
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

        [HttpDelete("Hard/{id}")]

        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectRepository.HardDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("Soft/{id}")]

        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectRepository.SoftDelete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
