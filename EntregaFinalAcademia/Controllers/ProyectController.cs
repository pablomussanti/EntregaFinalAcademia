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
    public class ProyectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProyectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Get all Proyects without state
        /// </summary>
        /// <returns> List of Proyects </returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proyects = await _unitOfWork.ProyectRepository.GetAll();

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateProyects = PaginateHelper.Paginate(proyects, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateProyects);
        }


        /// <summary>
        ///  Get All Proyects by state
        /// </summary>
        /// <returns> List of Proyects </returns>


        [HttpGet]
        [Route("ListState")]
        public async Task<IActionResult> GetAllState(Proyect.EstadoProyecto EstadoProyecto, Boolean EstadoActivo)
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

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateProyects = PaginateHelper.Paginate(listaCompletaProyects, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateProyects);
        }

        /// <summary>
        ///  Get a Proyect by ID
        /// </summary>
        /// <returns> A Proyect </returns>

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var proyect = await _unitOfWork.ProyectRepository.GetById(id);

            return ResponseFactory.CreateSuccessResponse(200, proyect);
        }


        /// <summary>
        ///  Create a Proyect
        /// </summary>
        /// <returns> Confirm state of request </returns>


        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Insert(ProyectDto dto)
        {

            var proyect = new Proyect(dto);
            var result = await _unitOfWork.ProyectRepository.Insert(proyect);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al crear el proyecto");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Proyecto creado con exito");
            }
        }

        /// <summary>
        ///  Update a Job
        /// </summary>
        /// <returns> Confirm state of request </returns>

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, ProyectDto dto)
        {
            var result = await _unitOfWork.ProyectRepository.Update(new Proyect(dto, id));


            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al modificar el proyecto");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto modificado con exito");
            }
        }

        /// <summary>
        ///  Delete a Job
        /// </summary>
        /// <returns> Confirm state of request </returns>

        [Authorize(Policy = "Admin")]
        [HttpDelete("Hard/{id}")]

        public async Task<IActionResult> HardDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectRepository.HardDelete(id);


            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el proyecto");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto eliminado con exito");
            }

        }


        /// <summary>
        ///  Delete a Job by state
        /// </summary>
        /// <returns> Confirm state of request </returns>
        

        [Authorize(Policy = "Admin")]
        [HttpDelete("Soft/{id}")]

        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectRepository.SoftDelete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error al eliminar el proyecto");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto eliminado con exito");
            }

        }
    }
}
