using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignaturaRepository
	{
		public AsignaturaRepository(TestContext context) : base(context)
		{

		}
	}
}