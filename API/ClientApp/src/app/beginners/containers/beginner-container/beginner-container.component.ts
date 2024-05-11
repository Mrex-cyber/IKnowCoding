import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, filter, interval, startWith, switchMap, takeUntil } from 'rxjs';
import { PassingTestComponent } from 'src/app/tests/components/passing-test/passing-test.component';
import { ITest } from 'src/app/tests/models/ITest';
import { TestsResourceService } from 'src/app/tests/resources/tests.service';
import { IUserSettings } from 'src/app/user-auth/models/IUserSettings';
import { UserAuthResourceService } from 'src/app/user-auth/resources/user-auth.service';

@Component({
  selector: 'app-beginner-container',
  templateUrl: './beginner-container.component.html',
  styleUrls: ['./beginner-container.component.css']
})
export class BeginnerContainerComponent implements OnInit, OnDestroy {
  public title: string = "Tests";

  public tests: ITest[] = [];

  public selectedTest?: ITest;

  public lastResult: string = "No result";

  private ngUnsubscribe = new Subject<void>();

  private authOptions: IUserSettings = {token: '', email: '', isAdmin: false };

  constructor(private testsService: TestsResourceService,
    private userAuthService: UserAuthResourceService,
    private dialog: MatDialog) { }

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
    this.lastResult = newResult.toString();

  }

  public onSelectTest(test: ITest): void {
    this.dialog.open(PassingTestComponent, {
      width: '50%',
      data: test
    });

    this.selectedTest = test;
  }

  public getTestsPolling(): void {

    interval(5000)
      .pipe(
        switchMap(() => this.testsService.getTests()),
        startWith([]),
        filter(tests => tests.length > 0),
        takeUntil(this.ngUnsubscribe)
      )
      .subscribe(tests => this.tests = tests);

  };

  //       <app-passing-test *ngIf="selectedTest" (newCurrentResultEvent)="changeTestResult($event)"></app-passing-test>

  public onChangeAuthOptions(){

    this.userAuthService.authOptions$
      .subscribe(options => {
        this.authOptions = options;

        if (this.authOptions.token !== ''){
          this.testsService.getUserTests(this.authOptions)
            .subscribe(tests => tests.map(test => this.tests.push(test)));
        }
      });

  }

}
