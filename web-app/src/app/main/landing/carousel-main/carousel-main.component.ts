import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProvinciasService } from '../../../services/provincias.service';

@Component({
  selector: 'app-carousel-main',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './carousel-main.component.html',
  styleUrl: './carousel-main.component.css',
})
export class CarouselMainComponent implements OnInit, OnDestroy {
  provincias: any[] = [];
  searchForm!: FormGroup;

  constructor(private provinciaServices: ProvinciasService) {}
  ngOnInit(): void {
    this.searchForm = new FormGroup({
      keyword: new FormControl('', [Validators.required]),
      province: new FormControl('', [Validators.required]),
    });
    this.loadProvincias();
  }

  loadProvincias(): void {
    this.provincias = [];
    this.provinciaServices.getAllProvincias().subscribe(
      (response) => {
        if (response) {
          this.provincias = response;
          //console.log(response);
        } else {
          console.log('No hay datos registrados');
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
  onsubmit() {}
  ngOnDestroy(): void {
    this.searchForm?.reset();
  }
}
