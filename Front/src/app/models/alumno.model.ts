import { AsignaturaAlumnos } from "./asignatura-alumno.model";
export class Alumno {
  id: number;
  identificacion: string;
  nombre: string;
  apellido: string;
  edad: number;
  direccion: string;
  telefono: string;
  asignaturas: AsignaturaAlumnos[];
}
