import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppUser } from '@shared/models/app-user';
import { EMPTY, map, Observable } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {

  user$: Observable<AppUser> = this.authService.user$;
  isLoggedIn$: Observable<boolean> = this.user$.pipe(map((x) => !!x.id));
  
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
              private authService: AuthService,
              private router: Router) {}

  ngOnInit(): void {
    this.isLoggedIn$.subscribe(x => {
      if (x) {
        this.router.navigate(['/dashboard']);
      }
    });
  }

  onLogin(): void {
    if (this.form.valid) {
      const data = this.form.value;
      
      this.authService
          .signIn(data.userName!, data.pwd!)
          .subscribe();
    }
  }
}
