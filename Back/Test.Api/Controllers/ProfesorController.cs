using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Profesor;

namespace Test.Api.Controllers
{
	/// <summary>
	///
	/// </summary>
	[Route("api/profesor")]
	[ApiController]
	public class ProfesorController : ControllerBase
	{
		private readonly IProfesorService _servicio;

		/// <summary>
		///
		/// </summary>
		/// <param name="servicio"></param>
		public ProfesorController(IProfesorService servicio)
		{
			_servicio = servicio;
		}

		/// <summary>
		/// Obtiene la lista de los profesores
		/// </summary>
		/// <returns></returns>
		[HttpGet("Listar")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<ListaProfesorDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Profesores()
		{
			var result = await _servicio.Listar();
			return Ok(result);
		}

		/// <summary>
		/// Consulta un profesor
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id:int}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<ListaProfesorDto>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ConsultaPor(int id)
		{
			var result = await _servicio.ConsultaPor(id);
			return Ok(result);
		}

		/// <summary>
		/// Crea un nuevo profesor
		/// </summary>
		/// <param name="entidad"></param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Crear([FromBody] CrearProfesorDto entidad)
		{
			var crear = await _servicio.Crear(entidad);
			return CreatedAtAction("Crear", crear);
		}

		/// <summary>
		/// Actualiza los datos del profesor
		/// </summary>
		/// <param name="entidad"></param>
		/// <returns></returns>
		[HttpPut]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Actualizar([FromBody] ActualizarProfesorDto entidad)
		{
			var actualizar = await _servicio.Actualizar(entidad);
			return CreatedAtAction("Actualizar", actualizar);
		}
	}
}