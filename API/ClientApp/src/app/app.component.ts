import { Component } from '@angular/core';
import { UserAuthResourceService } from './user-auth/resources/user-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private authService: UserAuthResourceService){
    this.authService.readLocalStorageUserData();
  }
}
