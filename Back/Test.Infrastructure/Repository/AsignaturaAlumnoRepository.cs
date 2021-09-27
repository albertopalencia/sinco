using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class AsignaturaAlumnoRepository : GenericRepository<AsignaturaAlumno>, IAsignaturasAlumnoRepository
	{
		public AsignaturaAlumnoRepository(TestContext context) : base(context)
		{
		}
	}
}