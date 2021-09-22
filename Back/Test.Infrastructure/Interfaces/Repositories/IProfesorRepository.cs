using Test.Domain.Entities;

namespace Test.Infrastructure.Interfaces.Repositories
{
	public interface IProfesorRepository: IReadRepository<Profesor>, ICreateRepository<Profesor>, IUpdateRepository<Profesor>
	{
		
	}
}