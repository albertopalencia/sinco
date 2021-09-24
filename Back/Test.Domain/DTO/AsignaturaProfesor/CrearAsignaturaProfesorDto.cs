namespace Test.Domain.DTO.AsignaturaProfesor
{
	public class CrearAsignaturaProfesorDto
	{
		public int IdAsignatura { get; set; }
		public int IdProfesor { get; set; }

		public CrearAsignaturaProfesorDto(int idAsignatura, int idProfesor)
		{
			IdAsignatura = idAsignatura;
			IdProfesor = idProfesor;
		}
		 

		public static implicit operator Entities.AsignaturaProfesor(CrearAsignaturaProfesorDto entidad)
		{
			return new()
			{
				IdAsignatura = entidad.IdAsignatura,
				IdProfesor = entidad.IdProfesor
			};
		}
	}
}