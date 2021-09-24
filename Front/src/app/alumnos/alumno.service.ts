import { Region } from './region';
import { Injectable } from '@angular/core';
import { Alumno } from './alumno';
import { HttpClient  } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { URL_BACKEND } from '../config/config';
import { Respuesta } from '../models/respuesta';


@Injectable()
export class AlumnoService {
  private urlEndPoint: string = URL_BACKEND + 'api/alumno';


  constructor(private http: HttpClient, private router: Router) { }


  getRegiones(): Observable<Region[]> {
    return this.http.get<Region[]>(this.urlEndPoint + '/regiones');
  }

  getAlumnos(): Observable<any> {
    return this.http.get(`${this.urlEndPoint}/listar`);
  }

  getAlumno(id: number): Observable<Respuesta> {
    return this.http.get<Respuesta>(`${this.urlEndPoint}/${id}`).pipe(
      catchError(e => {
        if(e.status != 401 && e.error.mensaje){
          console.log(e.error.mensaje)
          this.router.navigate(['/alumnos']);
        }
        return throwError(e);
      })
    );
  }

  create(alumno: Alumno): Observable<Alumno> {
    return this.http.post(this.urlEndPoint, alumno)
      .pipe(
        map((response: any) => response.result as Alumno),
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

  update(alumno: Alumno): Observable<any> {
    return this.http.put<any>(`${this.urlEndPoint}`, alumno).pipe(
      catchError(e => {
        if (e.status == 400) {
          return throwError(e);
        }

        if(e.error.mensaje){
          console.log(e.error.mensaje)
         }
        return throwError(e);
      })
    );
  }

  delete(id: number): Observable<Respuesta> {
    return this.http.delete<Respuesta>(`${this.urlEndPoint}/${id}`).pipe(
      catchError(e => {
        return throwError(e);
      })
    );
  }

}
