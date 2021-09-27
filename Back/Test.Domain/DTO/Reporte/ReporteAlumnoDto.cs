namespace Test.Domain.DTO.Reporte
{
	public class ReporteAlumnoDto
	{
		public string AnioAcademico { get; set; }
		public string IdentificacionAlumno { get; set; }

		public string NombreAlumno { get; set; }
		public int CodigoMateria { get; set; }
		public string NombreMateria { get; set; }

		public string IdentificacionProfesor { get; set; }
		public string NombreProfesor { get; set; }
		public string CalificacionFinal { get; set; }
		public string Aprobo { get; set; }
	}
}