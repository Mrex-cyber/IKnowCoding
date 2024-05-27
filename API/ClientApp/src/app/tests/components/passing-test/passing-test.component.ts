import { Component, Input, Output, EventEmitter, OnInit, Inject } from '@angular/core';
import { ITest } from '../../models/ITest';
import { IAnswer } from '../../models/IAnswer';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { UserAuthDialogComponent } from 'src/app/user-auth/dialog-windows/user-auth-dialog/user-auth-dialog.component';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-passing-test',
  templateUrl: './passing-test.component.html',
  styleUrls: ['./passing-test.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    FormsModule,
    MatButtonModule,
    ReactiveFormsModule
  ]
})
export class PassingTestComponent implements OnInit {
  @Input() test!: ITest;

  public selectedValues: IAnswer[] = [];

  constructor(
    public dialogRef: MatDialogRef<UserAuthDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ITest) {
    this.test = data;
  }

  ngOnInit() : void {
  }

  public submitForm(){
    this.dialogRef.close(this.selectedValues.filter(v => v !== null && v !== undefined));
  }

  public ngNoClick(): void {
    this.dialogRef.close();
  }

}
