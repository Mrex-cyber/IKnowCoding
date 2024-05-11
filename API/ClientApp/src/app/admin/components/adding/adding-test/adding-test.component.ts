import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormArray } from '@angular/forms';
import { AddingTestFormService } from '../../../services/adding-test-form.service';
import { Subject, Subscription, startWith, takeUntil } from 'rxjs';

@Component({
  selector: 'app-adding-test',
  templateUrl: './adding-test.component.html',
  styleUrls: ['./adding-test.component.css']
})
export class AddingTestComponent implements OnInit, OnDestroy{
  public newTest!: FormGroup;

  private testUnSubscriber = new Subject<void>();

  get questions() {
    return this.newTest.controls['questions'] as FormArray;
  }

  constructor(private addingTestFormService: AddingTestFormService) {
  }

  ngOnInit(): void {
    this.addingTestFormService.newTest$.pipe(
      takeUntil(this.testUnSubscriber)
    ).subscribe(emitedTest => this.newTest = emitedTest);
  }

  ngOnDestroy(): void {
    this.testUnSubscriber.next();
    this.testUnSubscriber.complete();
  }

  public getAnswers(index: number) : FormArray {
    return this.addingTestFormService.getAnswers(index);
  }

  public onSubmitTest(){
    console.log("Component submit");
    this.addingTestFormService.submitTest();
  }

  public addQuestion() {
    this.addingTestFormService.addQuestion();
  }

  public addAnswer(index: number) {
    this.addingTestFormService.addAnswer(index);
  }
}
