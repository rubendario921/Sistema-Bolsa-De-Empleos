import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-carousel-main',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './carousel-main.component.html',
  styleUrl: './carousel-main.component.css',
})
export class CarouselMainComponent implements OnInit, OnDestroy {
  provinces: any[] = [];
  searchForm!: FormGroup;
  ngOnInit(): void {
    this.searchForm = new FormGroup({
      keyword: new FormControl('', [Validators.required]),
      province: new FormControl('', [Validators.required]),
    });
  }
  onsubmit() {}
  ngOnDestroy(): void {
    this.searchForm?.reset();
  }
}
