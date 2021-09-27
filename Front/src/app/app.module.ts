import { AsignaturaService } from './services/asignatura.service';
import { ProfesorService } from './services/profesor.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AlumnosComponent } from './alumnos/alumnos.component';
import { FormComponent } from './alumnos/form.component';
import { AlumnoService } from './services/alumno.service';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { registerLocaleData } from '@angular/common';
import localeES from '@angular/common/locales/es';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatDatepickerModule } from '@angular/material';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { DetalleComponent } from './alumnos/detalle/detalle.component';
import { ProfesoresComponent } from './profesores/profesores.component';
import { DetalleProfesorComponent } from './profesores/detalle-profesor/detalle-profesor.component';
import { FormProfesorComponent } from './profesores/form-profesor/form-profesor.component';
import { AsignaturasComponent } from './asignaturas/asignaturas.component';
import { FormAsignaturaComponent } from './asignaturas/form-asignatura/form-asignatura.component';
import { AsignaturaAlumnoComponent } from './asignatura-alumno/asignatura-alumno.component';
import { ReportesComponent } from './reportes/reportes.component';
import { AsignaturaAlumnoService } from './services/asignatura-alumno.service';


registerLocaleData(localeES, 'es');

const routes: Routes = [
  { path: '', redirectTo: '/alumnos', pathMatch: 'full' },
  { path: 'alumnos', component: AlumnosComponent },
  { path: 'alumnos/form', component: FormComponent},
  { path: 'alumnos/form/:id', component: FormComponent},
  { path: 'profesores', component: ProfesoresComponent },
  { path: 'profesores/form', component: FormProfesorComponent},
  { path: 'profesores/form/:id', component: FormProfesorComponent},
  { path: 'asignaturas', component: AsignaturasComponent },
  { path: 'asignaturas/form', component: FormAsignaturaComponent},
  { path: 'asignaturas/form/:id', component: FormAsignaturaComponent},
  { path: 'reportes', component: ReportesComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    AlumnosComponent,
    FormComponent,
    DetalleComponent,
    ProfesoresComponent,
    DetalleProfesorComponent,
    FormProfesorComponent,
    AsignaturasComponent,
    FormAsignaturaComponent,
    AsignaturaAlumnoComponent,
    ReportesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    BrowserAnimationsModule, MatDatepickerModule, MatMomentDateModule
  ],
  providers: [
    AlumnoService,
    ProfesorService,
    AsignaturaService,
    AsignaturaAlumnoService,
    { provide: LOCALE_ID, useValue: 'es' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
