using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReporteController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReporteResponse), 201)]
        public async Task<IActionResult> CreateReporte(ReporteRequest request)
        {
            try
            {
                var result = await _reporteService.CreateReporte(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReporteResponse), 200)]
        public async Task<IActionResult> UpdateReporte(ReporteRequest request, int id)
        {
            try
            {
                var result = await _reporteService.UpdateReporte(request, id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 404 };
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReporteResponse), 200)]
        public async Task<IActionResult> GetReporteById(int id)
        {
            try
            {
                var result = await _reporteService.GetReporteById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReporteResponse>), 200)]
        public async Task<IActionResult> GetAllReportes()
        {
            var result = await _reporteService.GetAllReportes();
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("tipo/{tipo}")]
        [ProducesResponseType(typeof(List<ReporteResponse>), 200)]
        public async Task<IActionResult> GetReportesByTipo(string tipo)
        {
            try
            {
                var result = await _reporteService.GetReportesByTipo(tipo);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ReporteResponse), 200)]
        public async Task<IActionResult> DeleteReporte(int id)
        {
            try
            {
                var result = await _reporteService.DeleteReporte(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
