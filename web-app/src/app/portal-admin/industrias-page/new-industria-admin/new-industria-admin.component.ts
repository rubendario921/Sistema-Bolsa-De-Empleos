import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IndustriasService } from '../../../services/industrias.service';
import { industriaDTO } from '../../../models/industriasDTO.interface';
import { Router } from '@angular/router';
import { CustomToastrService } from '../../../services/custom-toastr.service';
@Component({
  selector: 'app-new-industria-admin',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './new-industria-admin.component.html',
  styleUrl: './new-industria-admin.component.css',
})
export class NewIndustriaAdminComponent implements OnInit, OnDestroy {
  //Variables
  newFormIndustria!: FormGroup;
  //
  constructor(
    private industriaService: IndustriasService,
    private fb: FormBuilder,
    private toast: CustomToastrService,
    private router: Router
  ) {
    this.newFormIndustria = this.fb.group({
      newName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]],
      newDescription: ['', [Validators.required]],
    });
  }
  ngOnInit(): void {}
  ngOnDestroy(): void {
    if (this.newFormIndustria) {
      this.newFormIndustria.reset();
    }
  }

  //Funciones
  newRegisterIndustria(): void {
    let newIndustriaData = this.newFormIndustria.value;
    let industriaDTO: industriaDTO = {
      indId: 0,
      indName: newIndustriaData.newName,
      indDetails: newIndustriaData.newDescription,
    };
    //console.log(rolDTO)
    this.industriaService.saveIndustria(industriaDTO).subscribe(
      (result) => {
        //console.log(result);
        this.toast.success('Industria creada con éxito');
        this.router.navigate(['industrias-page']).then(() => {
          window.location.reload();
        });
      },
      (error) => {
        console.error(error);
        this.toast.error('Error al crear la industria');
      }
    );
  }
}
