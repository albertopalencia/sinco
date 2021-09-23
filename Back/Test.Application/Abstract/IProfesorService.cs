using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.Profesor;

namespace Test.Application.Abstract
{
	public interface IProfesorService
	{
		Task<ResponseGenericDto<List<ListaProfesorDto>>> Listar();
		Task<ResponseGenericDto<ListaProfesorDto>> ConsultaPor(int id);
		Task<ResponseGenericDto<bool>> Crear(CrearProfesorDto entidad);
		Task<ResponseGenericDto<bool>> Actualizar(ActualizarProfesorDto entidad);
	}
}