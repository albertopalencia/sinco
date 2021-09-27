import { Component, OnInit } from '@angular/core';
import swal from 'sweetalert2';
import { ModalService } from '../services/modal.service';
import { Respuesta } from '../models/respuesta.model';
import { ProfesorService } from '../services/profesor.service';
import { Profesor } from '../models/profesor.model';


@Component({
  selector: 'app-profesores',
  templateUrl: './profesores.component.html',
  styleUrls: ['./profesores.component.css']
})
export class ProfesoresComponent implements OnInit {

  profesores: Profesor[];
  seleccionado: Profesor;

  constructor(private profesorService: ProfesorService, private modalService : ModalService  ) { }

  ngOnInit() {

     this.profesorService.getProfesores()
     .subscribe((response: Respuesta) => {
         this.profesores = response.result as Profesor[];
    });
  }

  delete(profesor: Profesor): void {
    swal({
      title: 'Está seguro?',
      text: `¿Seguro que desea eliminar al profesor ${profesor.nombre} ${profesor.apellido}?`,
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

        this.profesorService.delete(profesor.id).subscribe(
          () => {
            this.profesores = this.profesores.filter(al => al !== profesor)
            swal(
              'Profesor Eliminado!',
              `Profesor ${profesor.nombre} eliminado con éxito.`,
              'success'
            )
          }
        )

      }
    });
  }

  abrirModal(profesor: Profesor) {
    this.seleccionado = profesor;
    console.log(profesor);
    this.modalService.abrirModal();
  }

}
