import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsignaturaAlumnoComponent } from './asignatura-alumno.component';

describe('AsignaturaAlumnoComponent', () => {
  let component: AsignaturaAlumnoComponent;
  let fixture: ComponentFixture<AsignaturaAlumnoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsignaturaAlumnoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsignaturaAlumnoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
