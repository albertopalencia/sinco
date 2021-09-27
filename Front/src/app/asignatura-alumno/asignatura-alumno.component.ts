import { Component, Input, OnInit } from '@angular/core';
import { Alumno } from '../models/alumno.model';
import { Asignatura } from '../models/asignatura.model';
import { ModalService } from '../services/modal.service';
import { AsignaturaAlumnoService } from '../services/asignatura-alumno.service';
import { Router } from '@angular/router';
import swal from 'sweetalert2';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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

  errores: any;


  constructor(private fb: FormBuilder, public modalService: ModalService, private asignaturaAlumnoService: AsignaturaAlumnoService,  private router: Router) {
    this.formAsignaturaAlumno();
  }


  ngOnInit() {
  }

  formAsignaturaAlumno() {
    this.formRegistro = this.fb.group({
      idAsignatura: ['',[ Validators.required ] ],
      anio: ['', [ Validators.required, Validators.pattern('[0-9]+'), Validators.minLength(4) ,  Validators.maxLength(4) ] ],
      calificacion: ['', [ Validators.required, Validators.pattern('[0-9.]+[^.]') ] ]
    });
  }

  //#region Propiedades


  get asignaturaNovalid() {
    return this.formRegistro.get('idAsignatura').invalid && this.formRegistro.get('idAsignatura').touched;
  }
  get anioNovalid() {
    return this.formRegistro.get('anio').invalid && this.formRegistro.get('anio').touched;
  }
  get calificacionNovalid() {
    return this.formRegistro.get('calificacion').invalid && this.formRegistro.get('calificacion').touched;
  }

  //#endregion


  guardar(){
    let entidad = Object.assign({}, this.formRegistro.value);
    entidad.idAlumno = this.alumno.id;
    entidad.anioLectivo = entidad.anio;
    this.asignaturaAlumnoService.create(entidad)
    .subscribe(
      respuesta => {
        if (respuesta.success) {
          this.router.navigate(['/alumnos']);
          this.cerrarModal();
          swal('Asignar Asignaturas', `El alumno ${this.alumno.nombre} se le ha asignado la materia o asignatura con  éxito`, 'success');
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
