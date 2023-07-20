import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-addstudent',
  templateUrl: './addstudent.component.html',
  styleUrls: ['./addstudent.component.scss']
})
export class AddstudentComponent implements OnInit{
  type: string = "Password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  addstudentForm!: FormGroup;
  emailErrorMessage: string = '';
  passwordErrorMessage: string = '';

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.addstudentForm = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      LoginEmailId: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]],
      Dob: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
    }) 
  }

  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "Password";
  }

  onAddStudent() {
    if (this.addstudentForm.valid) {
      this.auth.addstudent(this.addstudentForm.value)
      .subscribe({
        next:(res=>{
          alert(res.message);
          this.addstudentForm.reset();
          this.router.navigate(['addstudent']);
        }),
        error: (err=>{
          alert(err?.error.message);
        })
      })

      console.log(this.addstudentForm.value)
    } else {
      this.validateAllFormFields(this.addstudentForm);
      alert("Your form is invalid");
    }
  }

  private validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }

  getLoginEmailErrorMessage() {
    const emailControl = this.addstudentForm.get('LoginEmailId');
    if (emailControl?.hasError('required')) {
      return 'Email is required.';
    } else if (emailControl?.hasError('email')) {
      return 'Invalid email address.';
    }
    return '';
  }

  getPasswordErrorMessage() {
    const passwordControl = this.addstudentForm.get('Password');
    if (passwordControl?.hasError('required')) {
      return 'Password is required.';
    } else if (passwordControl?.hasError('pattern')) {
      return 'Password must contain at least 8 characters, including an uppercase letter, a lowercase letter, a number, and a special symbol.';
    }
    return '';
  }
}

