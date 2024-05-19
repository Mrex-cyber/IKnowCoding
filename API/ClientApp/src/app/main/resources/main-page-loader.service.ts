import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAchievement } from 'src/app/tests/models/IAchievement';
import { IFeedback } from 'src/app/tests/models/IFeedback';

@Injectable({
  providedIn: 'root'
})
export class MainPageLoaderService {
  private mainPageUrl: string = "https://localhost:7214/api";

  private httpOptions = {
    headers: new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"})
  };

  constructor(private client: HttpClient) { }

  public getAchievements(): Observable<IAchievement[]> {
    this.httpOptions.headers = new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"});

    return this.client.get<IAchievement[]>(this.mainPageUrl + "/main/achievements", this.httpOptions);
  }

  public getFeedbacks(): Observable<IFeedback[]> {
    this.httpOptions.headers = new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"});

    return this.client.get<IFeedback[]>(this.mainPageUrl + "/main/feedbacks", this.httpOptions);
  }

}
