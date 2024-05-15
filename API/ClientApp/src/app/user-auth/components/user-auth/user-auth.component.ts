import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { catchError, tap, throwError } from 'rxjs';
import { UserAuthDialogComponent } from '../../dialog-windows/user-auth-dialog/user-auth-dialog.component';
import { UserRegistrationDialog } from '../../dialog-windows/user-register-dialog/user-register-dialog.component';
import { IUserCredentials } from '../../models/IUserCredentials';
import { UserAuthResourceService } from '../../resources/user-auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.css']
})
export class UserAuthComponent {
  public authorized: boolean = false;

  constructor(
    private authService: UserAuthResourceService,
    public dialog: MatDialog
    ) { }

  public userSignInSubmit(){
    const dialogRef = this.dialog.open(UserAuthDialogComponent, {
      height: '50%',
      width: '50%'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == null || result == undefined){
        console.log("Dialog was empty");
        return;
      }
      this.authorized = true;

      this.authService.userSignIn(result).pipe(
        catchError(error => {
          console.log('UserSigningInError: ' + error);
          return throwError(() => new Error('Wrong user signing in'));
        })
      ).subscribe(userData => {
        this.authService.updateAuthOptions({
          token: userData.token,
          email: userData.email,
          isAdmin: userData.isAdmin
        });
      });
    })
  }

  public userRegisterSubmit(){
    const dialogRef = this.dialog.open(UserRegistrationDialog, {
      height: '50%',
      width: '50%'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == null || result == undefined){
        console.log("Dialog was empty");
        return;
      }

      this.authService.userRegister(result).pipe(
        catchError(error => {
          console.log('UserRegisterError: ' + error);
          return throwError(() => new Error('Wrong user registration'));
        })
      ).subscribe();
    });
  }

  public logOut(){
    this.authorized = false;
    this.authService.logOut();
  }
}
