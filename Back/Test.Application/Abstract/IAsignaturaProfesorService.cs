using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.AsignaturaProfesor;

namespace Test.Application.Abstract
{
	public interface IAsignaturaProfesorService
	{
		Task<ResponseGenericDto<bool>> Adicionar(CrearAsignaturaProfesorDto entidad);
	}
}