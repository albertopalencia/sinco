import { Asignatura } from './../models/asignatura.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { URL_BACKEND } from '../config/config';
import { catchError, map } from 'rxjs/operators';
import { Respuesta } from '../models/respuesta.model';

@Injectable({
  providedIn: 'root'
})
export class AsignaturaService {

  private urlEndPoint: string = URL_BACKEND + 'api/asignatura';

  constructor(private http: HttpClient, private router: Router) { }

  getAsignaturasDisponible(): Observable<any> {
    return this.http.get(`${this.urlEndPoint}/disponibles`);
  }

  getAsignaturas(): Observable<any> {
    return this.http.get(`${this.urlEndPoint}/listar`);
  }

  getAsignatura(id: number): Observable<Respuesta> {
    return this.http.get<Respuesta>(`${this.urlEndPoint}/${id}`).pipe(
      catchError(e => {
        if(e.status != 401 && e.error.mensaje){
          console.log(e.error.mensaje)
          this.router.navigate(['/asignaturas']);
        }
        return throwError(e);
      })
    );
  }

  create(asignatura: Asignatura): Observable<Asignatura> {
    return this.http.post(this.urlEndPoint, asignatura)
      .pipe(
        map((response: any) => response.result as Asignatura),
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

  update(asignatura: Asignatura): Observable<any> {
    return this.http.put<any>(`${this.urlEndPoint}`, asignatura).pipe(
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


}
