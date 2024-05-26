import { Component, OnDestroy, OnInit } from '@angular/core';
import { TestsResourceService } from 'src/app/tests/resources/tests.service';
import { ITest } from '../../models/ITest';
import { UserAuthResourceService } from 'src/app/user-auth/resources/user-auth.service';
import { IUserSettings } from 'src/app/user-auth/models/IUserSettings';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { PassingTestComponent } from '../../components/passing-test/passing-test.component';
import { Subject, catchError, delay, filter, interval, of, retryWhen, startWith, switchMap, takeUntil, tap } from 'rxjs';
import { IQuestion } from '../../models/IQuestion';
import { MatButtonModule } from '@angular/material/button';
import { PassTestService } from '../../services/pass-test.service';

@Component({
  selector: 'app-tests-container',
  templateUrl: './tests-container.component.html',
  styleUrls: ['./tests-container.component.css']
})
export class TestsContainerComponent implements OnInit, OnDestroy {
  public title: string = "Tests";

  public tests: ITest[] = [];

  public selectedTest?: ITest;

  private ngUnsubscribe = new Subject<void>();
  private ngUnsubscribeDialog = new Subject<void>();

  private authOptions: IUserSettings = {access_token: '', refresh_token: '', email: '', isAdmin: false};

  constructor(private testsService: TestsResourceService,
    private userAuthService: UserAuthResourceService,
    private passTestService: PassTestService) { }

  ngOnInit(): void {
    this.onChangeAuthOptions();

    this.getTestsPolling();
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  public changeTestResult(newResult: number){
    this.selectedTest!.result = newResult;
  }

  public onSelectTest(test: ITest): void {
    this.selectedTest = test;

    test.result = this.passTestService.startPassingTestDialog(test);
  }

  public getTestsPolling(): void {
    interval(5000)
      .pipe(
        startWith(0),
        switchMap(() => {
          if (this.authOptions.access_token == ''){
            return this.testsService.getTests().pipe(
              catchError(err => {
                console.error('Error fetching tests:', err);
                return of([]);
              })
            );
          }
          else {
            return this.testsService.getUserTests(this.authOptions).pipe(
              catchError(err => {
                console.error('Error fetching user tests:', err);
                return of([]);
              })
            );
          };
        }),
        startWith([]),
        filter(tests => tests.length > 0),
        takeUntil(this.ngUnsubscribe),
        retryWhen(errors => errors.pipe(
          tap(error => console.error("Retrying after error: ", error)),
          delay(5000)
        ))
      )
      .subscribe(tests => this.tests = tests,
        error => console.error('Unexpected error:', error)
      );
  };

  public onChangeAuthOptions(){
    this.userAuthService.authOptions$
      .subscribe(options => {
        this.authOptions = options;
      });
  }

}
