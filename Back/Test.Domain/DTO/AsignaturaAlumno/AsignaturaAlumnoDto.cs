namespace Test.Domain.DTO.AsignaturaAlumno
{
	public class AsignaturaAlumnoDto
	{ 
		public int IdAsignatura { get; set; }
		public string Nombre { get; set; }
		public short AnioLectivo { get; set; }
		public byte Calificacion { get; set; }

		public static implicit operator AsignaturaAlumnoDto(Entities.AsignaturaAlumno entidad)
		{
			return new()
			{
				IdAsignatura = entidad.IdAsignatura,
				Nombre = entidad.IdAsignaturaNavigation?.Nombre,
				AnioLectivo = entidad.AnioLectivo,
				Calificacion = entidad.Calificacion
			};
		}
	}
}