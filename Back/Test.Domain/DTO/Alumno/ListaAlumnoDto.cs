﻿using System.Collections.Generic;
using System.Linq;
using Test.Domain.DTO.AsignaturaAlumno;

namespace Test.Domain.DTO.Alumno
{
	public class ListaAlumnoDto
	{
		public int Id { get; set; }
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public short Edad { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }

		public List<AsignaturaAlumnoDto> Asignaturas { get; set; }

		public static implicit operator ListaAlumnoDto(Entities.Alumno entidad)
		{
			var listaAsignaturas = entidad.AsignaturasAlumno.Select(asignatura => (AsignaturaAlumnoDto)asignatura).ToList();
			return new ListaAlumnoDto()
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