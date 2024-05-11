import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { UserAuthResourceService } from '../../user-auth/resources/user-auth.service';
import { IAnswer } from 'src/app/tests/models/IAnswer';
import { ITest } from 'src/app/tests/models/ITest';
import { IUserSettings } from 'src/app/user-auth/models/IUserSettings';

@Injectable({
  providedIn: 'root'
})
export class TestsResourceService {
  private testsUrl: string = "http://localhost:5016/api";

  private httpOptions = {
    headers: new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"})
  };

  constructor(private client: HttpClient) { }

  public getTests(): Observable<ITest[]> {
    this.httpOptions.headers = new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"});

    return this.client.get<ITest[]>(this.testsUrl + "/tests", this.httpOptions);
  }

  public getUserTests(authOptions: IUserSettings): Observable<ITest[]> {
    this.httpOptions.headers = new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json", "Authorization": "Bearer " + authOptions.token});

    return this.client.post<ITest[]>(this.testsUrl + "/tests" , JSON.stringify(authOptions.email), this.httpOptions);
  }

  public postTestResultWithId(authOptions: IUserSettings, testId: number, answers: IAnswer[]): Observable<number> {
    this.httpOptions.headers = new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json", "Authorization": "Bearer " + authOptions.token});

    return this.client.post<number>(this.testsUrl + "/tests/check" , JSON.stringify({userEmail: authOptions.email, testId, answers}), this.httpOptions);
  }
}
