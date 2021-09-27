using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.Reporte;

namespace Test.Application.Abstract
{
	public interface IReporteService
	{
		Task<ResponseGenericDto<List<ReporteAlumnoDto>>> ReporteAlumnos();
	}
}