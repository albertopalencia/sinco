using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Abstract;
using Test.Domain.DTO; 
using Test.Domain.DTO.Reporte;

namespace Test.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/reporte")]
	[ApiController]
	public class ReporteController :   ControllerBase
	{
		private readonly IReporteService _servicio;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="servicio"></param>
		public ReporteController(IReporteService servicio)
		{
			_servicio = servicio;
		}

		/// <summary>
		/// Obtiene el reporte de los alumnos
		/// </summary>
		/// <returns></returns>
		[HttpGet("CalificacionEstudiante")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<ReporteAlumnoDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Alumnos()
		{
			var result = await _servicio.ReporteAlumnos();
			return Ok(result);
		}
		 
	}
}