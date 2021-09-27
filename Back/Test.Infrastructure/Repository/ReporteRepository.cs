using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Common;
using Test.Common.Resources;
using Test.Domain.DTO.Reporte;
using Test.Infrastructure.Helpers;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class ReporteRepository : IReporteRepository
	{
		public async Task<List<ReporteAlumnoDto>> ReporteAlumnos()
		{
			var reporte = await
				DapperHelper.Instance.ExecuteQuerySelectAsync<ReporteAlumnoDto>(
					CommonHelpers.Instance.CadenaConexion,
					ReporteResources.ReporteAlumnos);

			return reporte.ToList();
		}
	}
}