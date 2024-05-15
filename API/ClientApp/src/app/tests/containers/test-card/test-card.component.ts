import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ITest } from '../../models/ITest';

@Component({
  selector: 'app-test-card',
  templateUrl: './test-card.component.html',
  styleUrls: ['./test-card.component.css']
})
export class TestCardComponent{
  @Input() test!: ITest;

  @Output() passTestCommand = new EventEmitter<ITest>();

  constructor() { }

  public passTest(){
    this.passTestCommand.emit(this.test);
  }

}
