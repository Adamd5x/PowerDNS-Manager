import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {

  form = this.fb.group({
    userName: ['', [
      Validators.required,
      Validators.minLength(5),
      Validators.maxLength(50)
    ]],
    pwd: ['', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(150)
    ]]
  });

  constructor(private fb: NonNullableFormBuilder,
              private authService: AuthService) {}

  ngOnInit(): void {
    
  }

  onLogin(): void {
    if (this.form.valid) {
      
    }
  }
}
