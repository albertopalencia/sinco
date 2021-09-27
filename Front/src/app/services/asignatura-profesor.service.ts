
import { Injectable } from '@angular/core';
import { HttpClient  } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { URL_BACKEND } from '../config/config';
import { Respuesta } from '../models/respuesta.model';
import { AsignaturaProfesor } from '../models/asignatura-profesor.model';
import { Observable, throwError } from 'rxjs';


@Injectable()
export class AsignaturaProfesorService {

  private urlEndPoint: string = URL_BACKEND + 'api/asignaturaprofesor';


  constructor(private http: HttpClient) { }

  create(asignaturaProfesor: AsignaturaProfesor): Observable<Respuesta> {
    return this.http.post(this.urlEndPoint, asignaturaProfesor)
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
