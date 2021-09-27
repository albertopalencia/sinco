import { Component, OnInit } from '@angular/core';
import { ReporteAlumno } from '../models/reporte-alumno.model';
import { Respuesta } from '../models/respuesta.model';
import { ExcelService } from '../services/excel.service';
import { ReporteService } from '../services/reporte.service';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent implements OnInit {

  data: ReporteAlumno[] = [];

  constructor(private excelService:ExcelService, private reporteService: ReporteService){ }

  ngOnInit() {
    this.consultaCalificaciones();
  }

  consultaCalificaciones() {
    this.reporteService.getCalificacionEstudiante()
    .subscribe((respuesta: Respuesta)=> {
      this.data = respuesta.result;
    });
  }

  exportarExcel():void {
    this.excelService.exportAsExcelFile(this.data, 'Calificaciones Estudiantes');
  }

}
