import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { ITest } from 'src/app/tests/models/ITest';
import { IUserCredentials } from 'src/app/user-auth/models/IUserCredentials';
import { IUserSettings } from 'src/app/user-auth/models/IUserSettings';

@Injectable({
  providedIn: 'root'
})
export class TestsAdminResourceService {

  private testsUrl: string = "https://localhost:7214/api";

  public defaultAuthOptions: IUserSettings = {token: '', email: '', isAdmin: false};

  private httpOptions = {
    headers: new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"})
  };

  constructor(private client: HttpClient) { }

  public onPostNewTest(test: FormGroup): Observable<any> {
    console.log("API request:");
    console.log(test.value);

    this.httpOptions.headers = new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json", "Authorization": "Bearer "});

    return this.client.post<any>(this.testsUrl + "/tests/new", JSON.stringify(test.value), this.httpOptions);
  }
}
