import { BaseModel } from "./BaseModel";
import { IQuestion } from "./IQuestion";

export interface ITest extends BaseModel {
  title: string;
  description: string;
  questions: IQuestion[];
  finished: boolean;
  result: number;
  imagePath: string;
}
