using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Asignatura;

namespace Test.Api.Controllers
{
	/// <summary>
	///
	/// </summary>
	[Route("api/asignatura")]
	[ApiController]
	public class AsignaturaController : ControllerBase
	{
		private readonly IAsignaturaService _servicio;

		/// <summary>
		///
		/// </summary>
		/// <param name="servicio"></param>
		public AsignaturaController(IAsignaturaService servicio)
		{
			_servicio = servicio;
		}

		/// <summary>
		/// Obtiene todos las materias o asignaturas
		/// </summary>
		/// <returns></returns>
		[HttpGet("Listar")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<ListaAsignaturaDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Asignaturas()
		{
			var result = await _servicio.Listar();
			return Ok(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet("disponibles")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<AsignaturaDisponibleDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> AsignaturasDisponibles()
		{
			var result = await _servicio.ListaDisponibles();
			return Ok(result);
		}


		/// <summary>
		/// Obtiene la asignatura
		/// </summary>
		/// <returns></returns>
		[HttpGet("{id:int}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<ListaAsignaturaDto>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ConsultaPor(int id)
		{
			var result = await _servicio.ConsultaPor(id);
			return Ok(result);
		}

		/// <summary>
		/// Crea una nueva asignatura
		/// </summary>
		/// <param name="entidad">The entidad.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CrearAsignatura([FromBody] CrearAsignaturaDto entidad)
		{
			var crear = await _servicio.Crear(entidad);
			return CreatedAtAction("CrearAsignatura", crear);
		}

		/// <summary>
		/// actualiza una asignatura
		/// </summary>
		/// <param name="entidad">The entidad.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ActualizarAsignatura([FromBody] ActualizarAsignaturaDto entidad)
		{
			var actualizar = await _servicio.Actualizar(entidad);
			return CreatedAtAction("ActualizarAsignatura", actualizar);
		}
	}
}