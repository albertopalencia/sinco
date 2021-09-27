import { Component, OnInit } from '@angular/core';
import { Asignatura } from '../models/asignatura.model';
import { Respuesta } from '../models/respuesta.model';
import { AsignaturaService } from '../services/asignatura.service';

@Component({
  selector: 'app-asignaturas',
  templateUrl: './asignaturas.component.html',
  styleUrls: ['./asignaturas.component.css']
})
export class AsignaturasComponent implements OnInit {

  asignaturas: Asignatura[];

  constructor(private asignaturaService: AsignaturaService) { }

  ngOnInit() {

    this.asignaturaService.getAsignaturas()
      .subscribe((response: Respuesta) => {
        this.asignaturas = response.result;
      });
  }

  cargarAsignaturas() {
    this.asignaturaService.getAsignaturas()
      .subscribe((response: { result: Asignatura[]; }) => {
        this.asignaturas = response.result as Asignatura[];
      });
  }

}
