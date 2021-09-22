using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Alumno;
using Test.Domain.Entities;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class AlumnoService : IAlumnoService
	{
		private readonly IAlumnoRepository _repositorio;
		public AlumnoService(IAlumnoRepository repositorio)
		{
			_repositorio = repositorio;
		}


		public async Task<ResponseGenericDto<bool>> Crear(CrearAlumnoDto entidad)
		{
			Alumno alumno = entidad;
			await _repositorio.AddAsync(alumno);
			return new ResponseGenericDto<bool>
			{
				Success = true
			};
		}

		public async Task<ResponseGenericDto<bool>> Actualizar(ActualizarAlumnoDto entidad)
		{
			Alumno alumno = entidad;
			await _repositorio.UpdateAsync(alumno);
			return new ResponseGenericDto<bool>
			{
				Success = true
			};
		}

		public async Task<ResponseGenericDto<List<ListaAlumnoDto>>> Listar()
		{ 
			var alumnos = await _repositorio.GetAllAsync(); 
			return new ResponseGenericDto<List<ListaAlumnoDto>>
			{
				Success = true,
				Result = alumnos.Select<Alumno, ListaAlumnoDto>(s => s).ToList()
			};
		}

		public async Task<ResponseGenericDto<ListaAlumnoDto>> ConsultaPor(int id)
		{
			var alumnos = await _repositorio.FirstOrDefaultAsync(f => f.Id == id);
			return new ResponseGenericDto<ListaAlumnoDto>
			{
				Success = true,
				Result = alumnos
			};
		}

		public async Task<ResponseGenericDto<bool>> Eliminar(int id)
		{
			var respuesta = new ResponseGenericDto<bool> {Success = true};
			var alumno = await _repositorio.FirstOrDefaultAsync(f => f.Id == id);
			if (alumno is null)
			{
				respuesta.Success = false;
				respuesta.Message = "No se encontro un alumno con ese id";
				return respuesta;
			}

			var tieneAsignaturas = alumno.AsignaturasAlumno.Count(c => c.IdAlumno == id);
			if (tieneAsignaturas > 0)
			{
				respuesta.Success = false;
				respuesta.Message = "No se puede eliminar el alumno, tiene asignado una o varias materias";
			}
			else
			{
				_repositorio.Remove(alumno); 
			}

			return respuesta;
		}
	}
}