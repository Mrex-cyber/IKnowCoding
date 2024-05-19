import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatBadgeModule } from '@angular/material/badge';
import { MatIconModule } from '@angular/material/icon';

import { FormArray, FormsModule, ReactiveFormsModule, FormGroupName } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { UserAuthComponent } from './user-auth/components/user-auth/user-auth.component';
import { TestsContainerComponent } from './tests/containers/tests-container/tests-container.component';
import { TestCardComponent } from './tests/containers/test-card/test-card.component';
import { BlogsContainerComponent } from './blogs/containers/blogs-container/blogs-container.component';
import { LocalizationComponent } from './main/localization/localization.component';
import { BeginnerContainerComponent } from './beginners/containers/beginner-container/beginner-container.component';
import { MainPageModule } from './main/containers/main-page/main-page.module';
import { MainRoutesComponent } from './navigation/components/main-routes/main-routes.component';
import { DotnetCertificationComponent } from './blogs/components/dotnet-certification/dotnet-certification.component';
import { ContactsContainerComponent } from './main/containers/contacts-container/contacts-container.component';
import { AddingTestComponent } from './admin/components/adding/adding-test/adding-test.component';

import { GoogleSigninComponent } from './user-auth/components/google-signin/google-signin.component';
//import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from 'angularx-social-login';

@NgModule({
  declarations: [
    AppComponent,
    UserAuthComponent,

    TestsContainerComponent,
    TestCardComponent,
    BlogsContainerComponent,
    LocalizationComponent,
    BeginnerContainerComponent,
    MainRoutesComponent,
    BlogsContainerComponent,
    DotnetCertificationComponent,
    ContactsContainerComponent,
    AddingTestComponent,

    GoogleSigninComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatButtonModule,
    MatDialogModule,
    MatBadgeModule,
    FormsModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,

    MainPageModule,
//    SocialLoginModule
  ],
  bootstrap: [AppComponent],
  // providers: [
  //   {
  //     provide: 'SocialAuthServiceConfig',
  //     useValue: {
  //       autoLogin: false,
  //       providers: [
  //         {
  //           id: GoogleLoginProvider.PROVIDER_ID,
  //           provider: new GoogleLoginProvider('47749442808-1b6mn80ppo0in57jbu2rp8fhcq8o658i.apps.googleusercontent.com')
  //         }
  //       ]
  //     } as SocialAuthServiceConfig,
  //   }
  // ]
})
export class AppModule { }
