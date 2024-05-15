import { Component } from '@angular/core';

@Component({
  selector: 'app-main-routes',
  templateUrl: './main-routes.component.html',
  styleUrls: ['./main-routes.component.css']
})
export class MainRoutesComponent {
  public menuIsOpen: boolean = false;

  public changeMenuState(){
    this.menuIsOpen = !this.menuIsOpen;
  }

}
