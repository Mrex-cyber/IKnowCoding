import { IAnswer } from "./IAnswer";

export interface IQuestion {
  id: number;
  text: string;
  answers: IAnswer[];
}
