import { Product } from './Product';

export interface Purchase {
  purchaseDate: Date;
  totalAmount: number;
  quantity: number;
  product?: Product;
}
