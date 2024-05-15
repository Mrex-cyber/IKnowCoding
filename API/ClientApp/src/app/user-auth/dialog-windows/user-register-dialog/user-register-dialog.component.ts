import { Component, Inject } from '@angular/core';
import { MatFormField } from '@angular/material/form-field';
import {
  MAT_DIALOG_DATA,
  MatDialogRef
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { IUserCredentials } from '../../models/IUserCredentials';

@Component({
  selector: 'app-user-auth-dialog',
  templateUrl: './user-register-dialog.component.html',
  styleUrls: ['./user-register-dialog.component.css'],
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
})
export class UserRegistrationDialog {
  public profileForm = new FormGroup ({
    firstNameFormControl: new FormControl(
      "", Validators.required
    ),
    lastNameFormControl: new FormControl(
      "", Validators.required
    ),
    emailFormControl: new FormControl(
      "", Validators.email
    ),
    passwordFormControl: new FormControl(
      "", Validators.minLength(8)
    )
  });

  constructor(
    public dialogRef: MatDialogRef<UserRegistrationDialog>,
    @Inject(MAT_DIALOG_DATA) public data: IUserCredentials
  ) { }

  public submitForm(){
    this.dialogRef.close({
      firstName: this.profileForm.get("firstNameFormControl")?.value,
      lastName: this.profileForm.get("lastNameFormControl")?.value,
      email: this.profileForm.get("emailFormControl")?.value,
      password: this.profileForm.get("passwordFormControl")?.value,
    });
  }

  public ngNoClick(): void {
    this.dialogRef.close();
  }

}
