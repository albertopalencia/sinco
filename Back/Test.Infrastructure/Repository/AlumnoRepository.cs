using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	 
	public class AlumnoRepository : GenericRepository<Alumno>, IAlumnoRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AlumnoRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public AlumnoRepository(TestContext context) : base(context)
		{
		}
	}
}