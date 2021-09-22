namespace Test.Domain.DTO.Asignatura
{
	public class ListaAsignaturaDto
	{
		public static implicit operator ListaAsignaturaDto(Entities.Asignatura entidad)
		{
			return new()
			{
				Nombre = entidad.Nombre,
				Id = entidad.Id
			};
		}

		public int Id { get; set; }

		public string Nombre { get; set; }
	}
}