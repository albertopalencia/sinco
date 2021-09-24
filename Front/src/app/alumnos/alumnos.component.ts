import { ModalService } from '../models/modal.service';
import { Component, OnInit } from '@angular/core';
import { Alumno } from './alumno';
import { AlumnoService } from './alumno.service';
import swal from 'sweetalert2';
import { Respuesta } from '../models/respuesta';

@Component({
  selector: 'app-alumnos',
  templateUrl: './alumnos.component.html'
})
export class AlumnosComponent implements OnInit {

  alumnos: Alumno[];
  seleccionado: Alumno;

  constructor(private alumnoService: AlumnoService, private modalService : ModalService  ) { }

  ngOnInit() {

     this.alumnoService.getAlumnos()
     .subscribe((response: { result: Alumno[]; }) => {
         this.alumnos = response.result as Alumno[];
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
            }else {
              swal(
                'Alerta!',
                `${respuesta.message}`,
                'warning' )
            }

          }
        )

      }
    });
  }

  abrirModal(alumno: Alumno) {
    this.seleccionado = alumno;
    console.log(alumno);
    this.modalService.abrirModal();
  }

}
