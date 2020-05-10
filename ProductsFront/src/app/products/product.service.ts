import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IProduct } from './product';
import { Observable, throwError } from 'rxjs';
import { catchError,tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  public productsUrl = 'http://localhost:54150/api/products';
  constructor(private http: HttpClient) { }
    getProducts(): Observable<IProduct[]> {
      return this.http.get<IProduct[]>(this.productsUrl).pipe(
          tap(data => console.log('All: ' + JSON.stringify(data)))
      );
  }
}
