import { Profesor } from './../../models/profesor.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfesorService } from '../../services/profesor.service';
import swal from 'sweetalert2';



@Component({
  selector: 'app-form-profesor',
  templateUrl: './form-profesor.component.html',
  styleUrls: ['./form-profesor.component.css']
})
export class FormProfesorComponent implements OnInit {


  profesor: Profesor = new Profesor();
  formRegistro: FormGroup;
  titulo: string = "Crear Profesor";
  errores: string[];

  constructor(private fb: FormBuilder, private profesorService: ProfesorService,
              private router: Router, private activatedRoute: ActivatedRoute) {
              this.formProfesor();
  }


  //#region Propiedades

  get identificacionNovalid() {
    return this.formRegistro.get('identificacion').invalid && this.formRegistro.get('identificacion').touched;
  }
  get nombreNovalid() {
    return this.formRegistro.get('nombre').invalid && this.formRegistro.get('nombre').touched;
  }
  get apellidoNovalid() {
    return this.formRegistro.get('apellido').invalid && this.formRegistro.get('apellido').touched;
  }
  get edadNovalid() {
    return this.formRegistro.get('edad').invalid && this.formRegistro.get('edad').touched;
  }
  get direccionNovalid() {
    return this.formRegistro.get('direccion').invalid && this.formRegistro.get('direccion').touched;
  }
  get telefonoNovalid() {
    return this.formRegistro.get('telefono').invalid && this.formRegistro.get('telefono').touched;
  }

  //#endregion


  formProfesor() {
    this.formRegistro = this.fb.group({
      identificacion:['', [ Validators.required, Validators.pattern('[0-9]+') ] ],
      nombre: ['', [ Validators.required ] ],
      apellido: ['', [ Validators.required  ] ],
      edad: ['', [ Validators.required, Validators.pattern('[0-9]+') ] ],
      direccion: ['', [ Validators.required ] ],
      telefono: ['', [ Validators.required, Validators.pattern('[0-9]+') ] ]
    });
  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(params => {
      let id = +params.get('id');
      if (id) {
        this.profesorService.getProfesor(id)
        .subscribe(response => {
            this.profesor = response.result;
            this.formRegistro.reset(this.profesor);
          });
        this.titulo = 'Editar Profesor';
      }
    });
  }

  create(): void {
    let profesor = this.formRegistro.value;
    this.profesorService.create(profesor)
      .subscribe(
        respuesta => {
          this.router.navigate(['/profesores']);
          swal('Nuevo Profesor', `El profesor ${profesor.nombre} ha sido creado con éxito`, 'success');
        },
        err => {
          this.errores = err.error as string[];
          console.error(err.error);
        }
      );

    this.titulo = 'Crear Profesor';
  }

  update(id: number): void {
    let profesor = this.formRegistro.value;
    profesor.id = id;
    this.profesorService.update(profesor)
      .subscribe(
        json => {
          this.router.navigate(['/profesores']);
          swal('Alumno Profesor', `Se actualizo el profesor: ${profesor.nombre}`, 'success');
        },
        err => {
          this.errores = err.error as string[];
          console.error(err.error);
        }
      )
  }

  regresar(): void {
    this.router.navigate(['/profesores']);
  }

}
