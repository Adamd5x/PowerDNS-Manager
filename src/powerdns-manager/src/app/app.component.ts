import { Component, OnInit } from '@angular/core';
import { EMPTY,
         Observable } from 'rxjs';
import { AppUser } from './shared/models/app-user';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  // isLoggedIn$: Observable<boolean> = EMPTY;
  // isLoggedOut$: Observable<boolean> = EMPTY;

  title = 'powerdns-manager';

  constructor(){}

  ngOnInit(): void {
    // const authService = inject(AuthService);
    // this.isLoggedIn$ = authService.isLoggedIn$;
    // this.isLoggedOut$ = authService.isLoggedOut$;
  }
  
}
