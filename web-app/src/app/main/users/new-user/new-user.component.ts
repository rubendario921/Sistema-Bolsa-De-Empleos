import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-user',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './new-user.component.html',
  styleUrl: './new-user.component.css'
})
export class NewUserComponent implements OnInit, OnDestroy {
  //Variables de Componente
  registerUser!: FormGroup ;  
  // constructor( private fb:FormBuilder, private router: Router){}
  
  ngOnInit(): void {
    //Formulario de registro
    this.registerUser = new FormGroup({
      name: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z ]+$/),]),
      lastname: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z ]+$/),]),


    })
  }
  ngOnDestroy(): void {   
    this.registerUser.reset();   
  }
  onsubmit(){}

}
