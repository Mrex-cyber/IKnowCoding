import { BaseModel } from "./BaseModel";

export interface IFeedback extends BaseModel {
  text: string;
  imagePath: Date;
  date: string;
  fullName: string;
}
