import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, filter, map, Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { ANONYMOUS_USER } from '../shared/models/anonymous-user';
import { AppUser } from '../shared/models/app-user';
import { ApiResponse } from '../shared/models/api-response';

@Injectable()
export class AuthService {

  private subject = new BehaviorSubject<AppUser>(ANONYMOUS_USER);

  user$: Observable<AppUser> = this.subject
                                   .asObservable();

  isLoggedIn$: Observable<boolean> = this.user$.pipe(map((user: AppUser) => !!user.id)); 
  isLoggedOut$: Observable<boolean> = this.isLoggedIn$.pipe(map(isLoggedIn => !isLoggedIn));

  constructor(private http: HttpClient) { }

  signIn(userName: string, password: string) {
    return this.http.post<ApiResponse<AppUser>>(`${environment.apiUrl}/api/auth`, {
      userName: userName,
      password: password
    }).pipe(
      filter((i:ApiResponse<AppUser>) => i.success),
      map((i: ApiResponse<AppUser>) => this.subject.next(i.data as AppUser)),
    );
  }
}
