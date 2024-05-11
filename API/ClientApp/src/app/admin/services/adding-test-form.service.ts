import { Injectable } from '@angular/core';
import { AbstractControl, Form, FormArray, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators, FormGroupName } from '@angular/forms';
import { TestsAdminResourceService } from '../resources/tests-admin-resource.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddingTestFormService {
  public newTest = new BehaviorSubject<FormGroup>(this.createTestForm());
  public newTest$ = this.newTest.asObservable();

  get questions() {
    return this.newTest.value.controls['questions'] as FormArray;
  }

  constructor(private testAdminService: TestsAdminResourceService) { }

  public submitTest(){
    console.log("Submitting test");
    this.testAdminService.onPostNewTest(this.newTest.value).subscribe(r => console.log(r)); // correct subscribtion!
  }

  public getAnswers(index: number) : FormArray {
    const questionsFormGroup = this.questions.controls.at(index) as FormGroup;
    const answersFormArray = questionsFormGroup.controls['answers'] as FormArray;

    return answersFormArray;
  }

  public addQuestion() {
    const questionsFormArray = this.newTest.value.get('questions') as FormArray;

    questionsFormArray.push(
      new FormGroup({
        text: new FormControl('', [Validators.required, this.angValidator]),
        answers: new FormArray([
          new FormGroup({
            text: new FormControl('', [Validators.required, this.angValidator])
          })
        ])
      })
    );
  }

  public addAnswer(index: number) {
    const questionsFormGroup = this.questions.controls.at(index) as FormGroup;
    const answersFormArray = questionsFormGroup.controls['answers'] as FormArray;

    answersFormArray.push(
      new FormGroup({
        text: new FormControl('', [Validators.required, this.angValidator])
      })
    )
  }

  public createTestForm() : FormGroup {
    return new FormGroup({
      title: new FormControl('', [Validators.required, this.angValidator]),
      description: new FormControl('', [Validators.required, this.angValidator]),
      questions: new FormArray<FormGroup>([
        new FormGroup({
          text: new FormControl('', [Validators.required, this.angValidator]),
          answers: new FormArray<FormGroup>([
            new FormGroup({
              text: new FormControl('', [Validators.required, this.angValidator])
            })
          ])
        })
      ])
    });
  }

  private angValidator(control: AbstractControl): ValidationErrors | null {
    if (!control || !control.value) {
      return {
        text: "Control is empty!"
      }
    }

    if (control.value.includes("angular")){
      return {
        text: "It can not include something like 'angular'"
      }
    }

    return null;
  }
}
