using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class AsignaturaProfesorRepository : GenericRepository<AsignaturaProfesor>, IAsignaturaProfesorRepository
	{
		public AsignaturaProfesorRepository(TestContext context) : base(context)
		{
		}
	}
}