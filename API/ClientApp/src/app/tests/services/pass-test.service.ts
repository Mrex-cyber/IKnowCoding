import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { PassingTestComponent } from '../components/passing-test/passing-test.component';
import { MatDialog } from '@angular/material/dialog';
import { ITest } from '../models/ITest';
import { TestsResourceService } from '../resources/tests.service';
import { UserAuthResourceService } from 'src/app/user-auth/resources/user-auth.service';
import { BehaviorSubject, Observable, Subject, Subscription, takeUntil } from 'rxjs';
import { IUserCredentials } from 'src/app/user-auth/models/IUserCredentials';
import { IUserSettings } from 'src/app/user-auth/models/IUserSettings';

@Injectable({
  providedIn: 'root'
})
export class PassTestService implements OnInit, OnDestroy{
  public lastTestResult: number = -1;

  private _subscriptions: Subscription[] = [];
  private _userCredentials: IUserSettings = {access_token: '', refresh_token: '', email: "", isAdmin: false };

  constructor(
    private dialog: MatDialog,
    private testsService: TestsResourceService,
    private authService: UserAuthResourceService) {
    }
  ngOnInit (): void {

  }

  ngOnDestroy (): void {
    this._subscriptions.map(s => s.unsubscribe());
  }

  public startPassingTestDialog(test: ITest): number {
    this.authService.authOptions$.subscribe(creds => this._userCredentials = creds).unsubscribe();

    this._subscriptions.push(
      this.dialog.open(PassingTestComponent, {
        data: test,
        width: '50%',
        height: '90%'
      })
      .afterClosed()
      .subscribe(
        result => {
          if (result == null){
            return test.result;
          }
          else{
            this._subscriptions.push(this.testsService
              .postTestResultWithId(this._userCredentials, test.id!, result)
              .subscribe(apiResult => result = apiResult));
            return result;
          }
      })
    );
    return 0;
  }
}
