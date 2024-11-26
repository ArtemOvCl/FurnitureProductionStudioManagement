import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  private apiUrl = 'https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json'; 

  constructor(private http: HttpClient) {}

  getRates(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
