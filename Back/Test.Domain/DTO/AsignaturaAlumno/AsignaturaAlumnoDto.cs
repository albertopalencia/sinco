namespace Test.Domain.DTO.AsignaturaAlumno
{
	public class AsignaturaAlumnoDto
	{ 
		public string Nombre { get; set; }
		public short AnioLectivo { get; set; }
		public byte Calificacion { get; set; }

		public static implicit operator AsignaturaAlumnoDto(Entities.AsignaturaAlumno entidad)
		{
			return new()
			{
				Nombre = entidad.IdAsignaturaNavigation?.Nombre,
				AnioLectivo = entidad.AnioLectivo,
				Calificacion = entidad.Calificacion
			};
		}
	}
}