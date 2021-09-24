using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Alumno;
using Test.Domain.DTO.Profesor;
using Test.Domain.Entities;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class ProfesorService : IProfesorService
	{
		private readonly IProfesorRepository _repositorio;
		public ProfesorService(IProfesorRepository repositorio)
		{
			_repositorio = repositorio;
		}
		public async Task<ResponseGenericDto<List<ListaProfesorDto>>> Listar()
		{
			var profesores = await _repositorio.GetAllAsync();
			return new ResponseGenericDto<List<ListaProfesorDto>>
			{
				Success = true,
				Result = profesores.Select<Profesor, ListaProfesorDto>(s => s).ToList()
			};
		}

		public async Task<ResponseGenericDto<DetalleProfesorDto>> ConsultaPor(int id)
		{
			var profesor = await _repositorio.BuscarProfesorPorId(id);
			return new ResponseGenericDto<DetalleProfesorDto>
			{
				Success = true,
				Result = profesor
			};
		}
		 

		public async Task<ResponseGenericDto<bool>> Crear(CrearProfesorDto entidad)
		{
			Profesor profesor = entidad;
			await _repositorio.AddAsync(profesor);
			return new ResponseGenericDto<bool>
			{
				Success = true
			};
		}

		public async Task<ResponseGenericDto<bool>> Actualizar(ActualizarProfesorDto entidad)
		{ 
			Profesor profesor = entidad;
			await _repositorio.UpdateAsync(profesor);
			return new ResponseGenericDto<bool>
			{
				Success = true
			};
		}
	}
}