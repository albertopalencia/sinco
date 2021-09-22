using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class AsignaturasAlumnoRepository : GenericRepository<AsignaturaAlumno>, IAsignaturasAlumnoRepository
	{
		public AsignaturasAlumnoRepository(TestContext context) : base(context)
		{
		}
	}
}