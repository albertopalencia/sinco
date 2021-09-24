using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Domain.DTO.Profesor;
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

		public async Task<DetalleProfesorDto> BuscarProfesorPorId(int id)
		{
			return await Entities.Where(s => s.Id == id).Include(i => i.AsiganturaProfesor)
				.ThenInclude(ii=> ii.IdAsignaturaNavigation).FirstOrDefaultAsync();
		}
	}
}