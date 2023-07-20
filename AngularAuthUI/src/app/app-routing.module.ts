import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AddteacherComponent } from './components/addteacher/addteacher.component';
import { AddstudentComponent } from './components/addstudent/addstudent.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';


const routes: Routes = [
  {path:'login', component: LoginComponent},
  {path: 'addteacher', component: AddteacherComponent},
  {path: 'addstudent', component: AddstudentComponent},
  {path: 'dashboard', component: DashboardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
