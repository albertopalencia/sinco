using System.Collections.Generic;
using System.Linq;
using Test.Domain.DTO.AsignaturaProfesor;

namespace Test.Domain.DTO.Profesor
{
	public class ListaProfesorDto
	{
		public int Id { get; set; }
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public short Edad { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }

		public List<AsignaturaProfesorDto> Asignaturas { get; set; }

		public static implicit operator ListaProfesorDto(Entities.Profesor entidad)
		{
			var listaAsignaturas = entidad.AsiganturaProfesor.Select(asignatura => (AsignaturaProfesorDto)asignatura).ToList();
			return new ListaProfesorDto()
			{
				Id = entidad.Id,
				Identificacion = entidad.Identificacion,
				Nombre = entidad.Nombre,
				Apellido = entidad.Apellido,
				Edad = entidad.Edad,
				Direccion = entidad.Direccion,
				Telefono = entidad.Telefono,
				Asignaturas = listaAsignaturas
			};
		}
	}
}