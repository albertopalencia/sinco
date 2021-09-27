using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Test.Domain.DTO.Alumno;
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

		public async Task<DetalleAlumnoDto> BuscarAlumnoPorId(int id)
		{
			return  await Entities.Where(s => s.Id == id)
								  .Include(i => i.AsignaturasAlumno)
								  .ThenInclude(ii=> ii.IdAsignaturaNavigation)
								  .FirstOrDefaultAsync();
		}
		 
	}
}