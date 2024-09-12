import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RolesService } from '../../../services/roles.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { Router } from '@angular/router';
import { rolesDTO } from '../../../models/rolesDTO';

@Component({
  selector: 'app-new-rol-admin',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './new-rol-admin.component.html',
  styleUrl: './new-rol-admin.component.css',
})
export class NewRolAdminComponent implements OnInit, OnDestroy {
  //Variables
  newFormRol!: FormGroup;
  //
  constructor(
    private rolService: RolesService,
    private fb: FormBuilder,
    private toast: CustomToastrService,
    private router: Router
  ) {
    this.newFormRol = this.fb.group({
      newName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]],
      newDescription: ['', [Validators.required]],
    });
  }
  ngOnInit(): void {}
  ngOnDestroy(): void {
    if(this.newFormRol){
      this.newFormRol.reset();
    }
  }

  //Funciones
  newRegisterRol(): void {
    let newRolData = this.newFormRol.value;
    let rolDTO: rolesDTO={
      rolId : 0,
      rolName: newRolData.newName,
      rolDescription: newRolData.newDescription
    };
    //console.log(rolDTO)
    this.rolService.saveRol(rolDTO).subscribe((result) => {
      //console.log(result);
      this.toast.success("Rol creado con éxito");
      this.router.navigate(['roles-page']).then(()=>{
        window.location.reload();
      })
    },(error)=>{      
      console.error(error)
      this.toast.error("Error al crear el rol")
    })

  }
}
