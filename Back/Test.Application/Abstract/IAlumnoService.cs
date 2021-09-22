using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.Alumno;

namespace Test.Application.Abstract
{
	public interface IAlumnoService
	{
		Task<ResponseGenericDto<bool>> Crear(CrearAlumnoDto entidad);
		Task<ResponseGenericDto<bool>> Actualizar(ActualizarAlumnoDto entidad);
		Task<ResponseGenericDto<List<ListaAlumnoDto>>> Listar();
		Task<ResponseGenericDto<ListaAlumnoDto>> ConsultaPor(int id);
		Task<ResponseGenericDto<bool>> Eliminar(int id);
	}
}