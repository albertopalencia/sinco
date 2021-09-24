import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Alumno } from '../models/alumno.model';
import { Asignatura } from '../models/asignatura.model';
import { ModalService } from '../services/modal.service';

@Component({
  selector: 'asignatura-alumno',
  templateUrl: './asignatura-alumno.component.html',
  styleUrls: ['./asignatura-alumno.component.css']
})
export class AsignaturaAlumnoComponent implements OnInit {

  @Input() alumno: Alumno;

  @Input() asignatura: Asignatura[];

  formRegistro: FormGroup;

  titulo: string = "Asociar Asignaturas";


  constructor(private fb: FormBuilder, public modalService: ModalService) {
    this.formAsignaturaAlumno();
  }


  ngOnInit() {
  }

  formAsignaturaAlumno() {
    this.formRegistro = this.fb.group({
      asignatura: ['',[ Validators.required ] ],
      anio: ['', [ Validators.required, Validators.pattern('[0-9]+') ] ],
      calificacion: ['', [ Validators.required, Validators.pattern('[0-5]+'),  Validators.maxLength(1) ] ]
    });
  }

  //#region Propiedades


  get asignaturaNovalid() {
    return this.formRegistro.get('asignatura').invalid && this.formRegistro.get('asignatura').touched;
  }
  get anioNovalid() {
    return this.formRegistro.get('anio').invalid && this.formRegistro.get('anio').touched;
  }
  get calificacionNovalid() {
    return this.formRegistro.get('calificacion').invalid && this.formRegistro.get('calificacion').touched;
  }

  //#endregion


  cerrarModal() {
    this.modalService.cerrarModal();
  }

}
