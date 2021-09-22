namespace Test.Domain.DTO.Alumno
{
	public class CrearAlumnoDto
	{
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public short Edad { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }

		 
		public static implicit operator Entities.Alumno(CrearAlumnoDto entidad) => new()
		{
			Identificacion = entidad.Identificacion,
			Nombre = entidad.Nombre,
			Apellido = entidad.Apellido,
			Edad = entidad.Edad,
			Direccion = entidad.Direccion,
			Telefono = entidad.Telefono
		};
	}
}