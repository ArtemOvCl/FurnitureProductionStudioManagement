import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FurnitureItem } from '../Interfaces/furniture-item';
import { FurnitureDetails } from '../Interfaces/furniture-details';

@Injectable({
  providedIn: 'root',
})
export class FurnitureService {
  private apiUrl = 'http://localhost:5221/api/Furniture';

  constructor(private http: HttpClient) {}

  getAllFurnitures(): Observable<FurnitureItem[]> {
    console.log("fwfwf");
    return this.http.get<FurnitureItem[]>(this.apiUrl);
  }

  getFurnitureById(id: number): Observable<FurnitureDetails> {
    return this.http.get<FurnitureDetails>(`${this.apiUrl}/${id}`);
  }

  deleteFurnitureById(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  updateFurniture(id: number, data: FormData): Observable<any> {

    console.log('FormData перед відправкою:');
    console.log(data)
    data.forEach((value, key) => {
      console.log(`${key}: ${value}`);
    });
    return this.http.put<any>(`${this.apiUrl}/${id}`, data);
  }

  addFurniture(data: FormData): Observable<any> {
    

    return this.http.post<any>(this.apiUrl, data);
  }
}
