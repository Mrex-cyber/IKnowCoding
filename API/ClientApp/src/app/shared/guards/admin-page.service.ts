import { Injectable, OnDestroy } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { Subscription } from 'rxjs';
import { IUserCredentials } from 'src/app/user-auth/models/IUserCredentials';
import { IUserSettings } from 'src/app/user-auth/models/IUserSettings';
import { UserAuthResourceService } from 'src/app/user-auth/resources/user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminPageService implements OnDestroy, CanActivate{
  private userSettings: IUserSettings = {access_token: '', refresh_token: '', email: '', isAdmin: false};;

  private userSettingsSubscription: Subscription = new Subscription();


  constructor(private authOptionsService: UserAuthResourceService){ }

  ngOnDestroy (): void {
    this.userSettingsSubscription.unsubscribe();
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {

    this.userSettingsSubscription = this.authOptionsService.authOptions$
      .subscribe(receivedUserSettings => this.userSettings = receivedUserSettings);

    console.log("Going to admin page!");
    console.log(this.userSettings);
    if (this.userSettings.access_token != "" && this.userSettings.email != "" && this.userSettings.isAdmin) {
      console.log("true admin page");
      return true;
    }
    else {
      console.log("false admin page");
      return false;
    }
  }

}
