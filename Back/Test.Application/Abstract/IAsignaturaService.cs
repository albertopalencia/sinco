using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.Asignatura;

namespace Test.Application.Abstract
{
	public interface IAsignaturaService
	{
		Task<ResponseGenericDto<List<ListaAsignaturaDto>>> Listar();
		Task<ResponseGenericDto<List<AsignaturaDisponibleDto>>> ListaDisponibles();
		Task<ResponseGenericDto<ListaAsignaturaDto>> ConsultaPor(int id);
		Task<ResponseGenericDto<bool>> Crear(CrearAsignaturaDto entidad);
		Task<ResponseGenericDto<bool>> Actualizar(ActualizarAsignaturaDto entidad);
	}
}