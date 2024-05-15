import { BaseModel } from "./BaseModel";

export interface IFeedback extends BaseModel {
  text: string;
  imagePath: string;
  date: string;
  fullName: string;
}
