import { Sale } from './Sale';
import { Purchase } from './Purchase';

export interface Product {
  productId: number;
  name: string ;
  description: string ;
  quantity: number;
  price: number;
  sales: Sale[] ;
  purchases: Purchase[] ;
}
