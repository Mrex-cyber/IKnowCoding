import { AfterViewInit, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserAuthResourceService } from '../../resources/user-auth.service';

declare const google: any;

@Component({
  selector: 'app-google-signin',
  templateUrl: './google-signin.component.html',
  styleUrls: ['./google-signin.component.css']
})
export class GoogleSigninComponent implements AfterViewInit {

  constructor( private authService: UserAuthResourceService) {
  }

  public userSignInWithGoogleButton(response?: any): void {
    console.log(response);
    return this.authService.userSignInWithGoogle(response.credential);
  }

  ngAfterViewInit() {
    this.renderButton();
  }

  handleCredentialResponse(response: any) {
    console.log('Logged in as: ' + response.credential);
    // Handle the response here, e.g., send it to your server for verification.
  }

  renderButton() {
    google.accounts.id.initialize({
      client_id: '47749442808-1b6mn80ppo0in57jbu2rp8fhcq8o658i.apps.googleusercontent.com',
      callback: this.onSuccess,
      onFailure: this.onFailure
    });

    google.accounts.id.renderButton(
      document.getElementById('g_id_onload'),
      { theme: 'outline', size: 'large' }  // customization attributes
    );
  }

  onSuccess(response: any) {
    console.log('Logged in as: ' + response.credential);
  }

  onFailure(error: any) {
    console.log('Error: ' + error);
  }
}
