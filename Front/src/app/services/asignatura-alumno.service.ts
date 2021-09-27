import { AsignaturaAlumnos } from './../models/asignatura-alumno.model';
import { Injectable } from '@angular/core';
import { HttpClient  } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { URL_BACKEND } from '../config/config';
import { Respuesta } from '../models/respuesta.model';


@Injectable()
export class AsignaturaAlumnoService {
  private urlEndPoint: string = URL_BACKEND + 'api/asignaturaalumno';


  constructor(private http: HttpClient) { }

  create(alumno: AsignaturaAlumnos): Observable<Respuesta> {
    return this.http.post(this.urlEndPoint, alumno)
      .pipe(
        map((response: any) => response as Respuesta),
        catchError(e => {
          if (e.status == 400) {
            return throwError(e);
          }
          if(e.mensaje){
           console.log(e.mensaje)
          }
          return throwError(e);
        })
      );
  }


}
