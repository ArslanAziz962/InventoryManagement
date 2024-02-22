import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import * as constants from '../../common/constants';
import { Purchase } from '../../models/Purchase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  constructor(private http: HttpClient) { }


  getAllPurchases(): Observable<Purchase[]> {
    const url = constants.BASE_URL + constants.PURCHASE_ENDPOINT + constants.GET_ALL_ACTION;

    return this.http.get<Purchase[]>(url);
  }

  purchaseProduct(pId: string, qty: number): Observable<string> {
    const url = constants.BASE_URL + constants.PURCHASE_ENDPOINT + constants.PURCHASE_PRODUCT_ACTION;

    let params = new HttpParams();
    params = params.append('productId', pId);
    params = params.append('quantity', qty.toString());


    return this.http.post<string>(url, null, { params: params });
  } 
}
