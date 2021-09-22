using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess
{
	/// <summary>
	/// Class TestContext.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class TestContext : DbContext
	{
		public TestContext()
		{
			
		}

		public TestContext(DbContextOptions<TestContext> options) : base(options)
		{

		}

		public virtual DbSet<Alumno> Alumnos { get; set; }
		public virtual DbSet<AsignaturaProfesor> AsiganturaProfesor { get; set; }
		public virtual DbSet<Asignatura> Asignaturas { get; set; }
		public virtual DbSet<AsignaturaAlumno> AsignaturasAlumno { get; set; }
		public virtual DbSet<Profesor> Profesores { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}