import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-addteacher',
  templateUrl: './addteacher.component.html',
  styleUrls: ['./addteacher.component.scss']
})
export class AddteacherComponent implements OnInit{

  type: string = "Password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  addteacherForm!: FormGroup;
  emailErrorMessage: string = '';
  passwordErrorMessage: string = '';

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.addteacherForm = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      LoginEmailId: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]],
      Dob: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
      Salary: ['', Validators.required],
    }) 
  }

  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "Password";
  }

  onAddTeacher() {
    if (this.addteacherForm.valid) {
      this.auth.addteacher(this.addteacherForm.value)
      .subscribe({
        next:(res=>{
          alert(res.message);
          this.addteacherForm.reset();
          this.router.navigate(['addteacher']);
        }),
        error: (err=>{
          alert(err?.error.message);
        })
      })

      console.log(this.addteacherForm.value)
    } else {
      this.validateAllFormFields(this.addteacherForm);
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
    const emailControl = this.addteacherForm.get('LoginEmailId');
    if (emailControl?.hasError('required')) {
      return 'Email is required.';
    } else if (emailControl?.hasError('email')) {
      return 'Invalid email address.';
    }
    return '';
  }

  getPasswordErrorMessage() {
    const passwordControl = this.addteacherForm.get('Password');
    if (passwordControl?.hasError('required')) {
      return 'Password is required.';
    } else if (passwordControl?.hasError('pattern')) {
      return 'Password must contain at least 8 characters, including an uppercase letter, a lowercase letter, a number, and a special symbol.';
    }
    return '';
  }
}
