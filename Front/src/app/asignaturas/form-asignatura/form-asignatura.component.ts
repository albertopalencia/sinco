import { AsignaturaService } from '../../services/asignatura.service';

import { Asignatura } from './../../models/asignatura.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import swal from 'sweetalert2';


@Component({
  selector: 'app-form-asignatura',
  templateUrl: './form-asignatura.component.html',
  styleUrls: ['./form-asignatura.component.css']
})
export class FormAsignaturaComponent implements OnInit {

  asignatura: Asignatura = new Asignatura();
  formRegistro: FormGroup;
  titulo: string = "Crear Asignatura";
  errores: string[];

  constructor(private fb: FormBuilder, private asignaturaService: AsignaturaService,
              private router: Router, private activatedRoute: ActivatedRoute) {
              this.formAsignatura();
  }


  //#region Propiedades

  get nombreNovalid() {
    return this.formRegistro.get('nombre').invalid && this.formRegistro.get('nombre').touched;
  }

  //#endregion


  formAsignatura() {
    this.formRegistro = this.fb.group({
      nombre: ['', [ Validators.required ] ]
    });
  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(params => {
      let id = +params.get('id');
      if (id) {
        this.asignaturaService.getAsignatura(id)
        .subscribe(response => {
            this.asignatura = response.result;
            this.formRegistro.reset(this.asignatura);
          });
        this.titulo = 'Editar Asignatura';
      }
    });
  }

  create(): void {
    let asignatura = this.formRegistro.value;
    this.asignaturaService.create(asignatura)
      .subscribe(
        Asignatura => {
          this.router.navigate(['/asignaturas']);
          swal('Nuevo Asignatura', `La asignatura ${asignatura.nombre} ha sido creado con éxito`, 'success');
        },
        err => {
          this.errores = err.error.errors as string[];
          console.error(err.error.errors);
        }
      );

    this.titulo = 'Crear Asignatura';
  }

  update(id: number): void {
    let asignatura = this.formRegistro.value;
    asignatura.id = id;
    this.asignaturaService.update(asignatura)
      .subscribe(
        json => {
          this.router.navigate(['/asignaturas']);
          swal('Asignatura Actualizada', 'Se actualizo la asignatura', 'success');
        },
        err => {
          this.errores = err.error.errors as string[];
          console.error(err.error.errors);
        }
      )
  }

  regresar(): void {
    this.router.navigate(['/asignaturas']);
  }

}
