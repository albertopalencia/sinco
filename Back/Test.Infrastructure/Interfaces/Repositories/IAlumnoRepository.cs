using Test.Domain.Entities;

namespace Test.Infrastructure.Interfaces.Repositories
{
	 
	public interface IAlumnoRepository : IReadRepository<Alumno>, ICreateRepository<Alumno>, IUpdateRepository<Alumno>, IRemoveRepository<Alumno>
	{
		
	}
}