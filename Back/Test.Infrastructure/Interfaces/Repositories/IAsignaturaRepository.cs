using Test.Domain.Entities;

namespace Test.Infrastructure.Interfaces.Repositories
{
	public interface IAsignaturaRepository : IReadRepository<Asignatura>, ICreateRepository<Asignatura>, IUpdateRepository<Asignatura>
	{
		
	}
}