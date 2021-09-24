using System.Threading.Tasks;
using Test.Domain.DTO.Alumno;
using Test.Domain.Entities;

namespace Test.Infrastructure.Interfaces.Repositories
{
	 
	public interface IAlumnoRepository : IReadRepository<Alumno>, ICreateRepository<Alumno>, IUpdateRepository<Alumno>, IRemoveRepository<Alumno>
	{
		Task<DetalleAlumnoDto> BuscarAlumnoPorId(int id);
	}
}