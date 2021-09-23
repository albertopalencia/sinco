using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.AsignaturaProfesor;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class AsignaturaProfesorService : IAsignaturaProfesorService
	{
		private readonly IAsignaturaProfesorRepository _repositorio;

		public AsignaturaProfesorService(IAsignaturaProfesorRepository repositorio)
		{
			_repositorio = repositorio;
		}

		public async Task<ResponseGenericDto<bool>> Adicionar(CrearAsignaturaProfesorDto entidad)
		{
			var resultado = new ResponseGenericDto<bool> { Success = true };
			if (TieneAsignaturaAsignada(entidad.IdProfesor))
			{
				resultado.Success = false;
				resultado.Message = "Una materia solo puede asignarse a un solo profesor";
			}
			else
			{
				await _repositorio.AddAsync(entidad);
			}
			
			return resultado;
		}

		private bool TieneAsignaturaAsignada(int idProfesor)
		{
			var cantidad =  _repositorio.Count(c => c.IdProfesor == idProfesor);
			return cantidad > 0;
		}
	}
}