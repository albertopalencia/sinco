 
 
 using System;

 namespace Test.Domain.Entities
{
    public class AsignaturaAlumno : Entity
    { 
        public int IdAlumno { get; set; }
        public int IdAsignatura { get; set; }
        public short AnioLectivo { get; set; }
        public decimal Calificacion { get; set; }

        public  Alumno IdAlumnoNavigation { get; set; }
        public  Asignatura IdAsignaturaNavigation { get; set; }
    }
}