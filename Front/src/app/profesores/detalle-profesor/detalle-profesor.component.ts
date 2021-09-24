import { Component, Input, OnInit } from '@angular/core';
import { ModalService } from '../../models/modal.service';
import { Profesor } from '../profesor.model';

@Component({
  selector: 'detalle-profesor',
  templateUrl: './detalle-profesor.component.html',
  styleUrls: ['./detalle-profesor.component.css']
})
export class DetalleProfesorComponent implements OnInit {

  @Input() profesor: Profesor;

  titulo: string = "Detalle del Profesor";

  constructor(public modalService: ModalService) { }

  ngOnInit() { }

  cerrarModal() {
    this.modalService.cerrarModal();
  }

}