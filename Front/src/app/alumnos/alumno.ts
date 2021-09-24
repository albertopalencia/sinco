import { AsignaturaAlumnos } from "../asignaturas/models/asignatura-alumno";
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
