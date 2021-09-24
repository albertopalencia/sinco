import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { Respuesta } from '../models/respuesta.model';
import { catchError, map } from 'rxjs/operators';
import { URL_BACKEND } from '../config/config';
import { Profesor } from '../profesores/profesor.model';

@Injectable({providedIn: 'root'})
export class ProfesorService {

  private urlEndPoint: string = URL_BACKEND + 'api/profesor';


  constructor(private http: HttpClient, private router: Router) { }

  getProfesores(): Observable<any> {
    return this.http.get(`${this.urlEndPoint}/listar`);
  }

  getProfesor(id: number): Observable<Respuesta> {
    return this.http.get<Respuesta>(`${this.urlEndPoint}/${id}`).pipe(
      catchError(e => {
        if(e.status != 401 && e.error.mensaje){
          console.log(e.error.mensaje)
          this.router.navigate(['/profesores']);
        }
        return throwError(e);
      })
    );
  }

  create(profesor: Profesor): Observable<Profesor> {
    return this.http.post(this.urlEndPoint, profesor)
      .pipe(
        map((response: any) => response.result as Profesor),
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

  update(profesor: Profesor): Observable<any> {
    return this.http.put<any>(`${this.urlEndPoint}`, profesor).pipe(
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

  delete(id: number): Observable<Profesor> {
    return this.http.delete<Profesor>(`${this.urlEndPoint}/${id}`).pipe(
      catchError(e => {
        return throwError(e);
      })
    );
  }

}
