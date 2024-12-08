import { Component } from '@angular/core';
import { HeaderMainComponent } from "../templates/header-main/header-main.component";

import { CommonModule } from '@angular/common';
import { NavbarFiltrosComponent } from "./navbar-filtros/navbar-filtros.component"; 

@Component({
    selector: 'app-postulaciones-page',
    imports: [HeaderMainComponent, CommonModule, NavbarFiltrosComponent],
    templateUrl: './postulaciones-page.component.html',
    styleUrl: './postulaciones-page.component.css'
})
export class PostulacionesPageComponent {

// Ejemplo quemado 
jobList = [
  {
    title: 'SUPERVISOR DE OPERACIONES',
    company: 'CORIS ECUADOR',
    location: 'Quito, Pichincha',
    jobType: 'Presencial',
    published: 'Publicado hoy'
  },
  {
    title: 'Ejecutivo de Ventas Quito',
    company: 'Norphone',
    location: 'Quito, Pichincha',
    jobType: 'Presencial',
    published: 'Publicado hoy'
  },
  {
    title: 'Ayudante de Cátedra Biología / Anatomía',
    company: 'QualityUp Soluciones Educativas',
    location: 'Loja, Loja',
    jobType: 'Presencial',
    published: 'Publicado hoy'
  }
  // agregar más empleos aquí
];


}
