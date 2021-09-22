
 namespace Test.Domain.Entities
{
    public class AsignaturaProfesor : Entity
    { 
        public int IdAsignatura { get; set; }
        public int IdProfesor { get; set; }

        public virtual Asignatura IdAsignaturaNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}