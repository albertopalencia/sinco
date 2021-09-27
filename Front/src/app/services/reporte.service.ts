import { Injectable } from '@angular/core';
import { HttpClient  } from '@angular/common/http';
import { Observable } from 'rxjs';
import { URL_BACKEND } from '../config/config';



@Injectable({providedIn: 'root'})
export class ReporteService {
  private urlEndPoint: string = URL_BACKEND + 'api/reporte';


  constructor(private http: HttpClient) { }


  getCalificacionEstudiante(): Observable<any> {
    return this.http.get(`${this.urlEndPoint}/CalificacionEstudiante`);
  }

}
