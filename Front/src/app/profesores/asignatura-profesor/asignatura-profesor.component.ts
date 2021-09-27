import { AsignaturaService } from './../../services/asignatura.service';
import { Respuesta } from './../../models/respuesta.model';
import { ModalService } from './../../services/modal.service';
import { AsignaturaProfesorService } from './../../services/asignatura-profesor.service';
import { Asignatura } from './../../models/asignatura.model';
import { Profesor } from './../../models/profesor.model';
import { Component, Input, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import swal from 'sweetalert2';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'asignatura-profesor',
  templateUrl: './asignatura-profesor.component.html',
  styleUrls: ['./asignatura-profesor.component.css']
})
export class AsignaturaProfesorComponent implements OnInit {

  @Input() profesor: Profesor;

  asignaturas: Asignatura[];

  formRegistro: FormGroup;

  titulo: string = "Asociar Asignatura";

  errores: any;


  constructor(private fb: FormBuilder, public modalService: ModalService,
    private asignaturaProfesorervice: AsignaturaProfesorService,
    private asignaturaService: AsignaturaService,
     private router: Router) {
    this.formAsignaturaProfesor();
  }


  ngOnInit() {
    this.asignaturaService.getAsignaturasDisponible()
    .subscribe((respuesta: Respuesta) => {
        this.asignaturas = respuesta.result;
    });
  }

  formAsignaturaProfesor() {
    this.formRegistro = this.fb.group({
      idAsignatura: ['',[ Validators.required ] ]
    });
  }

  //#region Propiedades


  get asignaturaNovalid() {
    return this.formRegistro.get('idAsignatura').invalid && this.formRegistro.get('idAsignatura').touched;
  }

  //#endregion


  guardar(){
    let entidad = Object.assign({}, this.formRegistro.value);
    entidad.idProfesor = this.profesor.id;
    this.asignaturaProfesorervice.create(entidad)
    .subscribe(
      respuesta => {
        if (respuesta.success) {
          this.cerrarModal();
          swal('Asignar Asignatura', `El profesor ${this.profesor.nombre} se le ha asignado la materia o asignatura con  éxito`, 'success');
          location.reload();
        }else {
          swal(
            'Alerta!',
            `${respuesta.message}`,
            'warning')
        }

      },
      err => {
        this.errores = err.error;
        console.error(err.error);
      });
  }

  cerrarModal() {
    this.modalService.cerrarModal();
  }

}
