using System.Linq;

namespace Test.Domain.DTO.Asignatura
{
	public class AsignaturaDisponibleDto
	{
		public static implicit operator AsignaturaDisponibleDto(Entities.Asignatura entidad)
		{
			return new()
			{
				Nombre = entidad.Nombre,
				Id = entidad.Id,
				Disponible = !entidad.AsiganturaProfesor.Any()
			};
		}

		public int Id { get; set; }

		public string Nombre { get; set; }

		public bool Disponible { get; set; }
	}
}