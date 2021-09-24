using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

		public async Task<List<Asignatura>> AsignaturaDisponibles()
		{ 
			var querye = await Entities.Include(i => i.AsiganturaProfesor).ToListAsync();
			return querye;
		}
	}
}