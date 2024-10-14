import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Country } from '../models';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Array<Country>> {
    return this.http.get<Array<Country>>(this.apiUrl + '/Country');
  }
}