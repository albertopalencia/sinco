using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Asignatura;
using Test.Domain.DTO.AsignaturaProfesor;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/asignaturaprofesor")]
	[ApiController]
	public class AsignaturaProfesorController : ControllerBase
	{
		private readonly IAsignaturaProfesorService _servicio;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="servicio"></param>
		public AsignaturaProfesorController(IAsignaturaProfesorService servicio)
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
		public async Task<IActionResult> Asignar([FromBody] CrearAsignaturaProfesorDto entidad)
		{
			var respuesta = await _servicio.Adicionar(entidad);
			return CreatedAtAction("Asignar", respuesta);
		}
	}
}