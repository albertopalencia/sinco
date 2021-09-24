using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Query;
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
			var alumnos = await _repositorio.GetAllAsync(include: q => q.Include(i=> i.AsignaturasAlumno).ThenInclude(t=> t.IdAsignaturaNavigation));
			return new ResponseGenericDto<List<ListaAlumnoDto>>
			{
				Success = true,
				Result = alumnos.Select<Alumno, ListaAlumnoDto>(s => s).ToList()
			};
		}

		public async Task<ResponseGenericDto<DetalleAlumnoDto>> ConsultaPor(int id)
		{
			var alumno = await _repositorio.BuscarAlumnoPorId(id);
			return new ResponseGenericDto<DetalleAlumnoDto>
			{
				Success = true,
				Result = alumno
			};
		}

		public async Task<ResponseGenericDto<bool>> Eliminar(int id)
		{
			var respuesta = new ResponseGenericDto<bool> { Success = true };
			var alumno = await _repositorio.BuscarAlumnoPorId(id);
			if (alumno is null)
			{
				respuesta.Success = false;
				respuesta.Message = "No se encontro un alumno con ese id";
				return respuesta;
			} 
			 
			if (alumno.Asignaturas.Count > 0)
			{
				respuesta.Success = false;
				respuesta.Message = "No se puede eliminar el alumno, tiene asignado una o varias materias";
			}
			else
			{
				var remueveAlumno = _repositorio.FirstOrDefault(s => s.Id == id);
				_repositorio.Remove(remueveAlumno);
			}

			return respuesta;
		}
	}
}