namespace Test.Domain.DTO.AsignaturaProfesor
{
	public class AsignaturaProfesorDto
	{
		public string Nombre { get; set; }
		public int? Id { get; set; }

		public static implicit operator AsignaturaProfesorDto(Entities.AsignaturaProfesor entidad)
		{
			return new()
			{
				Nombre = entidad.IdAsignaturaNavigation?.Nombre,
				Id = entidad.IdAsignaturaNavigation?.Id
			};
		}
	}
}