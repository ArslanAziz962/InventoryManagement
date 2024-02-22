import { Product } from './Product';

export interface Sale {
  saleId: number;
  saleDate: Date;
  quantity: number;
  totalAmount: number;
  product?: Product;
}
