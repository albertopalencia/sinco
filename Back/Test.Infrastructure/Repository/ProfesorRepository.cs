using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class ProfesorRepository : GenericRepository<Profesor>, IProfesorRepository
	{
		public ProfesorRepository(TestContext context) : base(context)
		{
		}
	}
}