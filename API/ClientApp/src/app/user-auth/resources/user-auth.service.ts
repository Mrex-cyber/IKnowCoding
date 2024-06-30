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

  public defaultAuthOptions: IUserSettings = {accessToken: '', refreshToken: '', email: '', isAdmin: false};

  private httpOptions = {
    headers: new HttpHeaders({"Accept": "application/json", "Content-Type": "application/json"})
  };

  private _authOptions = new BehaviorSubject<IUserSettings>(this.defaultAuthOptions);
  public authOptions$ = this._authOptions.asObservable();

  constructor(private client: HttpClient) { }

  public userSignIn(credentials: IUserCredentials): Observable<IUserSettings> {    
    this.readLocalStorageUserData();

    this.httpOptions.headers = new HttpHeaders({
      "Accept": "application/json", 
      "Content-Type": "application/json", 
      "Authorization": "Bearer " + this._authOptions.value.accessToken
    });

    this.client
      .post<IUserSettings>(
        this.testsUrl + "/user/signin", JSON.stringify({
          email: credentials.email,
          password: credentials.password
        }), this.httpOptions)
      .subscribe(response => this._authOptions.next(response));

      this.httpOptions.headers = new HttpHeaders({
        "Accept": "application/json", 
        "Content-Type": "application/json", 
        "Authorization": "Bearer " + this._authOptions.value.accessToken
      });
      
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

  public readLocalStorageUserData(): void{
    const userSettings: IUserSettings = {
      email: localStorage.getItem('email') ?? '',
      accessToken: localStorage.getItem('access_token') ?? '',
      refreshToken: localStorage.getItem('access_token') ?? '',
      isAdmin: localStorage.getItem('isAdmin') == 'true'
    }

    this._authOptions.next(userSettings);
  }

  public updateLocalAuthOptions(newAuthOptions: IUserSettings) {
    console.log("Auth: ", newAuthOptions)
    localStorage.setItem('email', newAuthOptions.email)
    localStorage.setItem('access_token', newAuthOptions.accessToken)
    localStorage.setItem('refresh_token', newAuthOptions.refreshToken)
    localStorage.setItem('isAdmin', newAuthOptions.isAdmin.toString())
  }

}
