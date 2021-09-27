using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.AsignaturaAlumno;

namespace Test.Application.Abstract
{
	public interface IAsignaturaAlumnoService
	{
		Task<ResponseGenericDto<bool>> Adicionar(CrearAsignaturaAlumnoDto entidad);
	}
}