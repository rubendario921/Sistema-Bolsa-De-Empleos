import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-rol-admin',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new-rol-admin.component.html',
  styleUrl: './new-rol-admin.component.css'
})
export class NewRolAdminComponent {
//Variables
newFormRol!: FormGroup

//Funciones
newRegisterRol():void{
  
}
}
