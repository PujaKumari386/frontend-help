import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit{
  public dateTime!: string;

  constructor(private router: Router) { }

  ngOnInit(): void {
    setInterval(() => {
      this.dateTime = new Date().toLocaleString();
    }, 1000);
  }
  onLogout(): void {
    this.router.navigateByUrl('/');
  }

}