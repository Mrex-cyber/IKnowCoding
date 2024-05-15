import { BaseModel } from "./BaseModel";

export interface IAchievement extends BaseModel {
  title: string;
  imagePath: string;
  text: string;
  date: string;
  source: string;
}
