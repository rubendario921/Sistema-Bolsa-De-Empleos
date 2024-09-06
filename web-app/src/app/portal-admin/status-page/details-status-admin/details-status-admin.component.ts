import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EstadosService } from '../../../services/estados.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';

@Component({
  selector: 'app-details-status-admin',
  templateUrl: './details-status-admin.component.html',
  styleUrls: ['./details-status-admin.component.css'],
})
export class DetailsStatusAdminComponent implements OnInit, OnDestroy {
  //Variable del Componente
  detailsStatusForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private statusService: EstadosService,
    private toasts: CustomToastrService
  ) {}

  ngOnInit(): void {}
  ngOnDestroy(): void {
    this.detailsStatusForm.reset();
  }

  DetailsStatus(): void {}
}
