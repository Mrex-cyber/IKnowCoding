import { BaseModel } from "./BaseModel";
import { IAnswer } from "./IAnswer";

export interface IQuestion extends BaseModel {
  text: string;
  answers: IAnswer[];
}
