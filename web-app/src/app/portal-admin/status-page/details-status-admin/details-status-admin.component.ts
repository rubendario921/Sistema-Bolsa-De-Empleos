import { Component, OnDestroy, OnInit } from '@angular/core';
import { FooterAdminComponent } from '../../template-admin/footer-admin/footer-admin.component';
import { HeaderAdminComponent } from '../../template-admin/header-admin/header-admin.component';
import { NavbarAdminComponent } from '../../template-admin/navbar-admin/navbar-admin.component';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  FormControl,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { estadoDTO } from '../../../models/estadosDTO.interface';
import { EstadosService } from '../../../services/estados.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-details-status-admin',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './details-status-admin.component.html',
  styleUrls: ['./details-status-admin.component.css'],
})
export class DetailsStatusAdminComponent implements OnInit, OnDestroy {
  //Variables para Formulario de actualización de Estados
  detailsStatusForm!: FormGroup;
  statusId!: number;
  statusDetail: estadoDTO[] = [];

  constructor(
    private estadoService: EstadosService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private toast: CustomToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    //Validaciones del Formulario
    this.detailsStatusForm = this.fb.group({
      estId: ['', Validators.required],
      estName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]],
      estCategory: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      estColor: ['', [Validators.required]],
    });
    //Obtener información por Id
    this.route.params.subscribe((params) => {
      this.statusId = params['id'];
      this.estadoService.getEstadoById(this.statusId).subscribe(
        (result: estadoDTO) => {
          //console.log(result);
          this.toast.success('Datos cargador correctamente');
          this.detailsStatusForm = this.fb.group({
            estId: [result.estId],
            estName: [result.estName],
            estCategory: [result.estCategory],
            estColor: [result.estColor],
          });
        },
        (error) => {
          console.error(error);
          this.toast.error('Error al cargar datos');
        }
      );
    });
  }
  ngOnDestroy(): void {
    this.detailsStatusForm.reset();
  }
  //Función para actualizar Estado
  updateStatus(): void {
    let updateStatusData = this.detailsStatusForm.value;
    let estadoDTO: estadoDTO = {
      estId: updateStatusData.estId,
      estName: updateStatusData.estName,
      estCategory: updateStatusData.estCategory,
      estColor: updateStatusData.estColor,
    };
    //console.log(estadoDTO);
    this.estadoService.updateEstado(estadoDTO.estId, estadoDTO).subscribe(
      (result) => {
        if (result) {
          this.toast.success('Estado actualizado correctamente');
          this.router.navigate(['/status-page']);
        } else {
          this.toast.error('Error al actualizar Estado');
        }
      },
      (error) => {
        console.error(error);
        this.toast.error('Error al actualizar Estado');
      }
    );
  }
  //Función para eliminar
  deleteStatus(): void {
    this.estadoService.deleteEstado(this.statusId).subscribe((result) => {
      if (result) {
        this.toast.success('Estado eliminado correctamente');
      } else {
        this.toast.error('Error al eliminar estado');
      }
    });
  }
}
