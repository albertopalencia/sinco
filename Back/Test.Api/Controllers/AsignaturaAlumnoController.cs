using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.AsignaturaAlumno;

namespace Test.Api.Controllers
{
	/// <summary>
	///
	/// </summary>
	[Route("api/asignaturaalumno")]
	[ApiController]
	public class AsignaturaAlumnoController : ControllerBase
	{
		private readonly IAsignaturaAlumnoService _servicio;

		/// <summary>
		///
		/// </summary>
		/// <param name="servicio"></param>
		public AsignaturaAlumnoController(IAsignaturaAlumnoService servicio)
		{
			_servicio = servicio;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="entidad"></param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Asignar([FromBody] CrearAsignaturaAlumnoDto entidad)
		{
			var respuesta = await _servicio.Adicionar(entidad);
			return CreatedAtAction("Asignar", respuesta);
		}
	}
}