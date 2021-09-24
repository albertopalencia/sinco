import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AlumnosComponent } from './alumnos/alumnos.component';
import { FormComponent } from './alumnos/form.component';
import { AlumnoService } from './alumnos/alumno.service';
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


registerLocaleData(localeES, 'es');

const routes: Routes = [
  { path: '', redirectTo: '/alumnos', pathMatch: 'full' },
  { path: 'alumnos', component: AlumnosComponent },
  { path: 'alumnos/form', component: FormComponent},
  { path: 'alumnos/form/:id', component: FormComponent},
  { path: 'profesores', component: ProfesoresComponent },
  { path: 'profesores/form', component: FormProfesorComponent},
  { path: 'profesores/form/:id', component: FormProfesorComponent},
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
    FormProfesorComponent
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
    AlumnoService, { provide: LOCALE_ID, useValue: 'es' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
