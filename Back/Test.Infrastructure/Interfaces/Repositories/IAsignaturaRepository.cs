using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Infrastructure.Interfaces.Repositories
{
	public interface IAsignaturaRepository : IReadRepository<Asignatura>, ICreateRepository<Asignatura>, IUpdateRepository<Asignatura>
	{
		Task<List<Asignatura>> AsignaturaDisponibles();
	}
}