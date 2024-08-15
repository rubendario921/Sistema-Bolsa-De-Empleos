import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';

@Component({
  selector: 'app-details-status-admin',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './details-status-admin.component.html',
  styleUrl: './details-status-admin.component.css',
})
export class DetailsStatusAdminComponent {
  //constructor
  constructor(
    public dialogRef: MatDialogRef<DetailsStatusAdminComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onClose():void{
    this.dialogRef.close();
  }
}
