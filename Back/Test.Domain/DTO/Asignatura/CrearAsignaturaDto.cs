namespace Test.Domain.DTO.Asignatura
{
	public class CrearAsignaturaDto
	{
		public string Nombre { get; set; }

		public static implicit operator Entities.Asignatura(CrearAsignaturaDto entidad)
		{
			return new()
			{
				Nombre = entidad.Nombre
			};
		}
		 
	}
}