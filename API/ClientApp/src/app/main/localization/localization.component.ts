import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-localization',
  templateUrl: './localization.component.html',
  styleUrls: ['./localization.component.css']
})
export class LocalizationComponent {
  public languages = [
    { code: 'en-US', label: 'English' },
    { code: 'ua', label: 'Українська' },
    { code: 'ru', label: 'Русский' }
  ]

  constructor(private router: Router) { }

  changeLanguage(event: any){
    this.router.navigate([`/${event.target.value}`]);
  }

}
