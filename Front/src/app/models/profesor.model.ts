import { Asignatura } from "./asignatura.model";

export class Profesor {
  id: number;
  identificacion: string;
  nombre: string;
  apellido: string;
  edad: number;
  direccion: string;
  telefono: string;
  asignaturas: Asignatura[];
}
