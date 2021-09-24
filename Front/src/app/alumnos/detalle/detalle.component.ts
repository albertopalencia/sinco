import { ModalService } from '../../models/modal.service';
import { Component, OnInit, Input } from '@angular/core';
import { Alumno } from '../alumno';


@Component({
  selector: 'detalle-alumno',
  templateUrl: './detalle.component.html',
  styleUrls: ['./detalle.css']
})
export class DetalleComponent implements OnInit {

  @Input() alumno: Alumno;

  titulo: string = "Detalle del Alumno";

  constructor(public modalService: ModalService) { }

  ngOnInit() { }

  cerrarModal() {
    this.modalService.cerrarModal();
  }

}
