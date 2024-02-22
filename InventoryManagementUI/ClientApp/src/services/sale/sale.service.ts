import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sale } from '../../models/Sale';
import * as constants from '../../common/constants';

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  constructor(private http: HttpClient) { }


  getAllSales(): Observable<Sale[]> {
    const url = constants.BASE_URL + constants.Sale_ENDPOINT + constants.GET_ALL_ACTION;

    return this.http.get<Sale[]>(url);
  }

  saleProduct(pId: string, qty: number): Observable<string> {
    const url = constants.BASE_URL + constants.Sale_ENDPOINT + constants.Sale_PRODUCT_ACTION;

    let params = new HttpParams();
    params = params.append('productId', pId);
    params = params.append('quantity', qty.toString());    
    return this.http.post<string>(url, null, { params: params });
  }
}
