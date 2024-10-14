import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { Country, User } from '../models';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly http: HttpClient) { }

  create(user: User): Observable<any> {
    return this.http.post(
        this.apiUrl + '/User/Register', 
        user,
        {
            headers: new HttpHeaders({'Content-Type': 'application/json'})
        });
  }
}