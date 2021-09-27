import { ModalService } from '../services/modal.service';
import { Component, OnInit } from '@angular/core';
import { Alumno } from '../models/alumno.model';
import { AlumnoService } from '../services/alumno.service';
import swal from 'sweetalert2';
import { Respuesta } from '../models/respuesta.model';
import { Asignatura } from '../models/asignatura.model';
import { AsignaturaService } from '../services/asignatura.service';

@Component({
  selector: 'app-alumnos',
  templateUrl: './alumnos.component.html'
})
export class AlumnosComponent implements OnInit {

  alumnos: Alumno[];
  seleccionado: Alumno;
  asignaturaAlumno: Alumno;
  asignaturas: Asignatura[];

  constructor(private alumnoService: AlumnoService, private modalService: ModalService,
    private modalAsignaturaService: ModalService, private asignaturaService: AsignaturaService) { }

  ngOnInit() {

    this.alumnoService.getAlumnos()
      .subscribe((response: { result: Alumno[]; }) => {
        this.alumnos = response.result as Alumno[];
        console.log(response.result);
      });
  }

  cargarAsignaturas() {
    this.asignaturaService.getAsignaturas()
      .subscribe((response: { result: Asignatura[]; }) => {
        this.asignaturas = response.result as Asignatura[];
      });
  }

  delete(alumno: Alumno): void {
    swal({
      title: 'Está seguro?',
      text: `¿Seguro que desea eliminar al alumno ${alumno.nombre} ${alumno.apellido}?`,
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!',
      cancelButtonText: 'No, cancelar!',
      confirmButtonClass: 'btn btn-success',
      cancelButtonClass: 'btn btn-danger',
      buttonsStyling: false,
      reverseButtons: true
    }).then((result) => {
      if (result.value) {

        this.alumnoService.delete(alumno.id).subscribe(
          (respuesta: Respuesta) => {
            if (respuesta.success) {
              this.alumnos = this.alumnos.filter(al => al !== alumno)
              swal(
                'Alumno Eliminado!',
                `Alumno ${alumno.nombre} eliminado con éxito.`,
                'success'
              )
            } else {
              swal(
                'Alerta!',
                `${respuesta.message}`,
                'warning')
            }

          }
        )

      }
    });
  }

  abrirModal(alumno: Alumno) {
    this.seleccionado = alumno;
    this.asignaturaAlumno = null;
    this.modalService.abrirModal();
  }

  asignaturaAbrilModal(alumno: Alumno) {
    this.asignaturaAlumno = alumno;
    this.seleccionado = null;
    this.cargarAsignaturas();
    this.modalAsignaturaService.abrirModal();
  }

}


