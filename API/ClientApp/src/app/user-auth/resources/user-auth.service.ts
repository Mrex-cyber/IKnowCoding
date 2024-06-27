import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IUserCredentials } from '../models/IUserCredentials';
import { IUserSettings } from '../models/IUserSettings';

@Injectable({
  providedIn: 'root'
})
export class UserAuthResourceService {
  private testsUrl: string = "https://localhost:7214/api";

  public defaultAuthOptions: IUserSettings = {access_token: '', refresh_token: '', email: '', isAdmin: false};

  private httpOptions = {
    headers: new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"})
  };

  private _authOptions = new BehaviorSubject<IUserSettings>(this.defaultAuthOptions);
  public authOptions$ = this._authOptions.asObservable();

  constructor(private client: HttpClient) { }

  public userSignIn(credentials: IUserCredentials): Observable<IUserSettings> {
    console.log(JSON.stringify({
      email: credentials.email,
      password: credentials.password
  }))
    this.readLocalStorageUserData();

    this.httpOptions.headers = new HttpHeaders({
      "Accept": "application/json", 
      "Content-Type": "application/json", 
      "Authorization": "Bearer " + this._authOptions.value.access_token
    });

    this.client
      .post<IUserSettings>(
        this.testsUrl + "/user/signin", JSON.stringify({
          email: credentials.email,
          password: credentials.password
        }), this.httpOptions)
      .subscribe(result => this.updateAuthOptions(result));

    return this.authOptions$;
  }

  public userSignInWithGoogle(token: string): void {
    const responsePayload = JSON.parse(atob(token.split(".")[1]));
    console.log("RESPONSE");
    console.log(responsePayload);
  }

  public userRegister(credentials: IUserCredentials): Observable<string> {
    this.httpOptions.headers = new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"});
    return this.client.post<string>(this.testsUrl + "/user/signup", {firstName: credentials.firstName, lastName: credentials.lastName, email: credentials.email, password: credentials.password});
  }

  public logOut(){
    this._authOptions.next(this.defaultAuthOptions);

    location.reload();
  }

  public readLocalStorageUserData(){
    const userSettings: IUserSettings = {
      email: localStorage.getItem('email') ?? '',
      access_token: localStorage.getItem('access_token') ?? '',
      refresh_token: localStorage.getItem('access_token') ?? '',
      isAdmin: localStorage.getItem('isAdmin') == 'true'
    }

    this._authOptions.next(userSettings);
  }

  public updateAuthOptions(newAuthOptions: IUserSettings) {
    localStorage.setItem('email', this._authOptions.value.email)
    localStorage.setItem('access_token', this._authOptions.value.access_token)
    localStorage.setItem('refresh_token', this._authOptions.value.refresh_token)
    localStorage.setItem('isAdmin', this._authOptions.value.isAdmin.toString())

    this._authOptions.next(newAuthOptions);
  }

}
