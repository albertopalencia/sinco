using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.AsignaturaAlumno;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class AsignaturaAlumnoService : IAsignaturaAlumnoService
	{
		private readonly IAsignaturasAlumnoRepository _repositorio;
		public AsignaturaAlumnoService(IAsignaturasAlumnoRepository repositorio)
		{
			_repositorio = repositorio;
		}
		public async Task<ResponseGenericDto<bool>> Adicionar(CrearAsignaturaAlumnoDto entidad)
		{
			var resultado = new ResponseGenericDto<bool> { Success = true };
			if (TieneAsignaturaMismoAnio(entidad))
			{
				resultado.Success = false;
				resultado.Message = "El alumno ya tiene esta materia asignada para este año";
			}
			else
			{
				await _repositorio.AddAsync(entidad);
			}

			return resultado;
		} 

		private bool TieneAsignaturaMismoAnio(CrearAsignaturaAlumnoDto entidad)
		{
			var cantidad = _repositorio.Count(c => 
										   c.IdAlumno == entidad.IdAlumno &&
										   c.IdAsignatura == entidad.IdAsignatura && 
										   c.AnioLectivo == entidad.AnioLectivo);
			return cantidad > 0;
		}
	}
}