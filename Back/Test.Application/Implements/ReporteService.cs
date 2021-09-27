using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Reporte;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class ReporteService : IReporteService
	{
		private readonly IReporteRepository _repositorio;

		public ReporteService(IReporteRepository repositorio)
		{
			_repositorio = repositorio;
		}

		public async Task<ResponseGenericDto<List<ReporteAlumnoDto>>> ReporteAlumnos()
		{
			var respuesta = new ResponseGenericDto<List<ReporteAlumnoDto>>
			{
				Success = true,
				Result = await _repositorio.ReporteAlumnos()
			};

			return respuesta;
		}
	}
}