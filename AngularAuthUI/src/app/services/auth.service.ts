import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl:string = "https://localhost:44311/api/"
  constructor(private http : HttpClient) { }

  login(loginObj: any){
    return this.http.post<any>(`${this.baseUrl}Login/authentication`,loginObj);
  }

  addteacher(roleObj: any){
    return this.http.post<any>(`${this.baseUrl}Role/teacher/add`,roleObj);
  }

  addstudent(roleObj: any){
    return this.http.post<any>(`${this.baseUrl}Role/student/add`,roleObj);
  }
}
