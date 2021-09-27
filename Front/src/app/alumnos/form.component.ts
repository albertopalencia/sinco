import { Component, OnInit } from '@angular/core';
import { Alumno } from '../models/alumno.model';
import { AlumnoService } from '../services/alumno.service';
import { Router, ActivatedRoute } from '@angular/router';
import swal from 'sweetalert2';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html'
})
export class FormComponent implements OnInit {

  alumno: Alumno = new Alumno();
  formRegistro: FormGroup;
  titulo: string = "Crear Alumno";
  errores: string[];

  constructor(private fb: FormBuilder, private alumnoService: AlumnoService,
              private router: Router, private activatedRoute: ActivatedRoute) {
              this.formAlumnos();
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


  formAlumnos() {
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
        this.alumnoService.getAlumno(id)
        .subscribe(response => {
            this.alumno = response.result;
            this.formRegistro.reset(this.alumno);
          });
        this.titulo = 'Editar Alumno';
      }
    });

    //this.alumnoService.getRegiones().subscribe(regiones => { this.regiones = regiones; });
  }

  create(): void {
    let alumno = this.formRegistro.value;
    this.alumnoService.create(alumno)
      .subscribe(
        Alumno => {
          this.router.navigate(['/alumnos']);
          swal('Nuevo Alumno', `El alumno ${alumno.nombre} ha sido creado con éxito`, 'success');
        },
        err => {
          this.errores = err.error as string[];
          console.error(err.error);
        }
      );

    this.titulo = 'Crear Alumno';
  }

  update(id: number): void {
    let alumno = this.formRegistro.value;
    alumno.id = id;
    this.alumnoService.update(alumno)
      .subscribe(
        json => {
          this.router.navigate(['/alumnos']);
          swal('Alumno Actualizado', `Se actualizo el alumno: ${alumno.nombre}`, 'success');
        },
        err => {
          this.errores = err.error as string[];
          console.error(err.error);
        }
      )
  }

  regresar(): void {
    this.router.navigate(['/alumnos']);
  }

}
