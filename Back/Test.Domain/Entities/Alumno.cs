  
using System.Collections.Generic;


namespace Test.Domain.Entities
{
    public class Alumno : Entity
    {
        public Alumno()
        {
            AsignaturasAlumno = new HashSet<AsignaturaAlumno>();
        }
         
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public ICollection<AsignaturaAlumno> AsignaturasAlumno { get; set; }
    }
}