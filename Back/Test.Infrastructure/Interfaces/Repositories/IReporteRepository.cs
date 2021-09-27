using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.DTO.Reporte;

namespace Test.Infrastructure.Interfaces.Repositories
{
	public interface IReporteRepository
	{
		Task<List<ReporteAlumnoDto>> ReporteAlumnos();
	}
}