import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse, HttpHeaders } from '@angular/common/http'
import { Observable,throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { INAS_Price } from './NAS_Price';
import { IHD_Price } from './HD_Price';
import { IBasicCost } from './BasicCost';
import { IComision } from './Comision';



@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  nas: INAS_Price; // To get tha NAS for the price
  hdsPrice: IHD_Price[] = []; // To get the hard drives


  getBasicCosts(): Observable<IBasicCost[]> {
    return this.http.get<IBasicCost[]>("/api/BasicCosts").pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError));

  }
  getComision(): Observable<IComision[]> {
    return this.http.get<IComision[]>("/api/Comisions").pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError));

  }

  getNAS(): Observable<INAS_Price[]> {
    return this.http.get<INAS_Price[]>("/api/NAS_Empty").pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError));

  }


  getHD(): Observable<IHD_Price[]> {
    return this.http.get<IHD_Price[]>("/api/HardDrives").pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError));

  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = 'An error occurred: ${err.error.message}';
    } else {
      errorMessage = 'Server returned code: ${err.status}, error message is: ${err.message}';
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
