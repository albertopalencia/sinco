namespace Test.Domain.DTO.Asignatura
{
	public class ActualizarAsignaturaDto
	{  
		public int Id { get; set; }
		public string Nombre { get; set; }

		public static implicit operator Entities.Asignatura(ActualizarAsignaturaDto entidad)
		{
			return new()
			{
				Nombre = entidad.Nombre,
				Id = entidad.Id
			};
		}
	}
}