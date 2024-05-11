import { IQuestion } from "./IQuestion";

export interface ITest {
  id?: number;
  title: string;
  description: string;
  questions: IQuestion[];
  finished: boolean;
  result: number;
}
