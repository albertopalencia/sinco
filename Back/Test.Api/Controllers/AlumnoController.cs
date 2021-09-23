using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Alumno;

namespace Test.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/alumno")]
	[ApiController]
	public class AlumnoController :   ControllerBase
	{
		private readonly IAlumnoService _servicio;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="servicio"></param>
		public AlumnoController(IAlumnoService servicio)
		{
			_servicio = servicio;
		}

		/// <summary>
		/// Obtiene todos los alumnos
		/// </summary>
		/// <returns></returns>
		[HttpGet("Listar")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<ListaAlumnoDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Alumnos()
		{
			var result = await _servicio.Listar();
			return Ok(result);
		}

		/// <summary>
		/// Obtiene todos los alumnos
		/// </summary>
		/// <returns></returns>
		[HttpGet("{id:int}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<ListaAlumnoDto>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ConsultaPor(int id)
		{
			var result = await _servicio.ConsultaPor(id);
			return Ok(result);
		}

		/// <summary>
		/// Crea un nuevo alumno
		/// </summary>
		/// <param name="entidad">The entidad.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CrearAlumno([FromBody]  CrearAlumnoDto entidad)
		{
			var crear = await _servicio.Crear(entidad);
			return CreatedAtAction("CrearAlumno", crear);
		}

		/// <summary>
		/// actualiza un alumno
		/// </summary>
		/// <param name="entidad">The entidad.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Actualizar([FromBody] ActualizarAlumnoDto entidad)
		{
			var actualizar = await _servicio.Actualizar(entidad);
			return CreatedAtAction("Actualizar", actualizar);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Eliminar(int id)
		{
			var eliminar = await _servicio.Eliminar(id);
			return CreatedAtAction("Eliminar", eliminar);
		}	
	}
}