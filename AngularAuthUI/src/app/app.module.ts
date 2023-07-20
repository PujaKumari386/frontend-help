import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AddteacherComponent } from './components/addteacher/addteacher.component';
import { AddstudentComponent } from './components/addstudent/addstudent.component';
import { BannerComponent } from './banner/banner.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { KhaliComponent } from './khali/khali.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AddteacherComponent,
    AddstudentComponent,
    BannerComponent,
    HeaderComponent,
    FooterComponent,
    DashboardComponent,
    KhaliComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
