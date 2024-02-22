import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import * as constants from '../../common/constants';
import { Product } from '../../models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }
  addProduct(model: Product): Observable<void> {
    const url = constants.BASE_URL + constants.PRODUCT_ENDPOINT + constants.CREAET_ACTION;

    return this.http.post<void>(url, model);
  }
  getAllProducts(): Observable<Product[]> {
    const url = constants.BASE_URL + constants.PRODUCT_ENDPOINT + constants.GET_ALL_ACTION;

    return this.http.get<Product[]>(url);
  }
  deleteProduct(id: string): Observable<boolean> {
    const url = constants.BASE_URL + constants.PRODUCT_ENDPOINT + constants.DELETE_ACTION+'/'+id;

    return this.http.delete<boolean>(url);
  }

  updateProduct(id: string, model: Product): Observable<boolean> {
    //model.productId = 0;
    const url = constants.BASE_URL + constants.PRODUCT_ENDPOINT + constants.UPDATE_ACTION + '/' + id;

    return this.http.put<boolean>(url,model);
  }
}
