import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { provinciasDTO } from '../../../models/provinciasDTO';
import { ProvinciasService } from '../../../services/provincias.service';

@Component({
  selector: 'app-new-oferta-empresas',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './new-oferta-empresas.component.html',
  styleUrl: './new-oferta-empresas.component.css',
})
export class NewOfertaEmpresasComponent {
  //Variables
  newFormOferta!: FormGroup;
  allProvincias: provinciasDTO[] = [];
  //Constructor
  constructor(private provinciaService: ProvinciasService) {}
  //Funciones
  registerNewOferta(): void {}
  loadProvincias(): void {
    this.provinciaService.getAllProvincias().subscribe(
      (result) => {
        if (result != null) {
          this.allProvincias = result;
        } else {
          console.error(result);
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
