import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Province } from '../models';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly http: HttpClient) { }

  getByCountryName(name: string): Observable<Array<Province>> {
    return this.http.get<Array<Province>>(this.apiUrl + '/Province/ByCountryName/' + name);
  }

  getByCountryId(id: number): Observable<Array<Province>> {
    return this.http.get<Array<Province>>(this.apiUrl + '/Province/ByCountryId/' + id);
  }

  get(id: number): Observable<Province> {
    return this.http.get<Province>(this.apiUrl + '/Province/' + id);
  }
}