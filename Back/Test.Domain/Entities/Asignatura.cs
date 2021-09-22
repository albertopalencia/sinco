using System.Collections.Generic;

namespace Test.Domain.Entities
{
    public class Asignatura : Entity
    {
        public Asignatura()
        {
            AsiganturaProfesor = new HashSet<AsignaturaProfesor>();
            AsignaturasAlumno = new HashSet<AsignaturaAlumno>();
        }
         
        public string Nombre { get; set; }

        public   ICollection<AsignaturaProfesor> AsiganturaProfesor { get; set; }
        public   ICollection<AsignaturaAlumno> AsignaturasAlumno { get; set; }
    }
}