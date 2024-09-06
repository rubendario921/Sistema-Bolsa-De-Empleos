import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { EstadosService } from '../../../services/estados.service';
import { estadoDTO } from '../../../models/estadosDTO.interface';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-status-admin',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './new-status-admin.component.html',
  styleUrl: './new-status-admin.component.css',
})
export class NewStatusAdminComponent implements OnInit, OnDestroy {
  //Variables de Componentes
  newFormStatus!: FormGroup;

  //Constructor
  constructor(
    private fb: FormBuilder,
    private statusService: EstadosService,
    private toasts: CustomToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    //Validaciones de formulario
    this.newFormStatus = this.fb.group({
      newName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]],
      newCategory: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      newColor: ['', [Validators.required]],
    });
  }
  ngOnDestroy(): void {
    this.newFormStatus.reset();
  }

  onsubmitNewStatus(): void {
    let newStatusData = this.newFormStatus.value;
    let estadoDTO: estadoDTO = {
      estId: 0,
      estName: newStatusData.newName,
      estCategory: newStatusData.newCategory,
      estColor: newStatusData.newColor,
    };
    this.statusService.saveEstado(estadoDTO).subscribe(
      (response) => {
        if (response) {
          console.log(response);
          this.toasts.success('Estado creado con éxito');
          this.router.navigate(['status-page']).then(() => {
            window.location.reload();
          });
        } else {
          this.toasts.error('Error al crear el estado');
        }
      },
      (error) => {
        console.error(error);
        this.toasts.error('Error al crear el estado');
      }
    );
  }
}
