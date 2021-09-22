using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Asignatura;
using Test.Domain.Entities;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class AsignaturaService : IAsignaturaService
	{

		private readonly IAsignaturaRepository _repositorio;
		public AsignaturaService(IAsignaturaRepository repositorio)
		{
			_repositorio = repositorio;
		}

		public async Task<ResponseGenericDto<List<ListaAsignaturaDto>>> Listar()
		{
			var asignaturas = await _repositorio.GetAllAsync();
			return new ResponseGenericDto<List<ListaAsignaturaDto>>
			{
				Success = true,
				Result = asignaturas.Select<Asignatura, ListaAsignaturaDto>(s => s).ToList()
			};
		}

		public async Task<ResponseGenericDto<ListaAsignaturaDto>> ConsultaPor(int id)
		{
			var asignatura = await _repositorio.FirstOrDefaultAsync(f => f.Id == id);
			return new ResponseGenericDto<ListaAsignaturaDto>
			{
				Success = true,
				Result = asignatura
			};
		}

		public async Task<ResponseGenericDto<bool>> Crear(CrearAsignaturaDto entidad)
		{
			Asignatura asignatura = entidad;
			await _repositorio.AddAsync(asignatura);
			return new ResponseGenericDto<bool>
			{
				Success = true
			};
		}

		public async Task<ResponseGenericDto<bool>> Actualizar(ActualizarAsignaturaDto entidad)
		{
			Asignatura asignatura = entidad;
			await _repositorio.UpdateAsync(asignatura);
			return new ResponseGenericDto<bool>
			{
				Success = true
			};
		}
	}
}