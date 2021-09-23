namespace Test.Domain.DTO.AsignaturaAlumno
{
	public class CrearAsignaturaAlumnoDto
	{
		public int IdAlumno { get; set; }
		public int IdAsignatura { get; set; }
		public short AnioLectivo { get; set; }
		public byte Calificacion { get; set; }

		public static implicit operator Entities.AsignaturaAlumno(CrearAsignaturaAlumnoDto entidad)
		{
			return new()
			{
				IdAsignatura = entidad.IdAsignatura,
				IdAlumno = entidad.IdAlumno,
				AnioLectivo = entidad.AnioLectivo,
				Calificacion = entidad.Calificacion
			};
		}
	}
}