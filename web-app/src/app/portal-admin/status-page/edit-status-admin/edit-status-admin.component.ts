import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { TestApiService } from '../../../services/test-api.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-edit-status-admin',
  standalone: true,
  imports: [MatDialogModule,MatFormFieldModule,ReactiveFormsModule,MatInputModule],
  templateUrl: './edit-status-admin.component.html',
  styleUrl: './edit-status-admin.component.css',
})
export class EditStatusAdminComponent {
  //Variables
  editForm!: FormGroup;

  //constructor
  constructor(
    public dialogRef: MatDialogRef<EditStatusAdminComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private testApiService: TestApiService,
    private toastr: CustomToastrService
  ) {
    this.editForm = this.fb.group({
      id: [data.id],
      first_name: [data.first_name, Validators.required],
      last_name: [data.last_name, Validators.required],
      email: [data.email, [Validators.required, Validators.email]],
      avatar: [data.avatar],
    });
  }
  onSubmit(): void {
    if (this.editForm.valid) {
      this.testApiService.updateUser(this.editForm.value).subscribe(
        (response: any) => {
          console.log('User updated successfully', response);
          this.toastr.success('Usuario actualizado correctamente', 'Correcto');
          this.dialogRef.close();
        },
        (error: any) => {
          console.error('Error updating user', error);
          this.toastr.error('Error al actualizar', 'Error');
        }
      );
    }
  }
  onClose(): void {
    this.dialogRef.close();
  }
}
