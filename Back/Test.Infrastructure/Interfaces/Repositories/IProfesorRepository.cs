using System.Threading.Tasks;
using Test.Domain.DTO.Profesor;
using Test.Domain.Entities;

namespace Test.Infrastructure.Interfaces.Repositories
{
	public interface IProfesorRepository : IReadRepository<Profesor>, ICreateRepository<Profesor>, IUpdateRepository<Profesor>
	{
		Task<DetalleProfesorDto> BuscarProfesorPorId(int id);
	}
}