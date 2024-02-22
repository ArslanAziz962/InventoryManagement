import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from '../../models/Product';
import { ProductService } from '../../services/product/product.service';
import { PurchaseService } from '../../services/purchase/purchase.service';
import { SaleService } from '../../services/sale/sale.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnDestroy {

  products: Product[];
  subscription?: Subscription;
  deleteSubscription?: Subscription;
  purchaseSubscription?: Subscription;
  saleSubs?: Subscription;
  isError: boolean;
  isLoading: boolean = true;
  constructor(private productService: ProductService, private purchaseService: PurchaseService, private saleService: SaleService, private router: Router) {
    this.products = [];
    this.isError = false;
    this.getAllProducts();
  }

  getAllProducts() {

    this.subscription = this.productService.getAllProducts().subscribe({
      next: (response) => {
        console.log('products:', response);
        this.products = response;
        this.isLoading = false;
      },
      error: (error) => {
        this.isError = true;
        this.isLoading = false;

        console.error('error when getting products:', error)
      }
    })


  }


  deleteProduct(id: string) {

    if (window.confirm(`Are you sure you want to delete product with ID: ${id}?`)) {
      // Delete the product

      console.log('product id:', id)
      this.deleteSubscription = this.productService.deleteProduct(id).subscribe({
        next: (response) => {
          this.getAllProducts();
        },
        error: (error) => {
          console.error('error when deleting product ', error);
        }
      })
    }
    
  }

  salePurchaseProduct(id: string, isPurchase: boolean) {

    try {
      let quantity = prompt('Please Enter Quantity:')      
      if (quantity != null && quantity!=='') {
        let numberQuantity = parseInt(quantity);
        if (numberQuantity.toString() !== 'NaN') {


          if (isPurchase) {

            this.purchaseSubscription = this.purchaseService.purchaseProduct(id, numberQuantity).subscribe({
              next: (response) => {
                alert('Purchased successfully');

                this.getAllProducts();
              },
              error: (error) => {
                alert('Error when purchasing product');

                console.error('error when purchasing product ', error);
              }
            })
          } else {
            this.saleSubs =this.saleService.saleProduct(id, numberQuantity).subscribe({
              next: (response) => {
                alert('Sold successfully');

                this.getAllProducts();
              },
              error: (error) => {
                alert('Error when selling product');

                console.error('error when selling product ', error);
              }
            })
          }




        } else {
          alert('Invalid Quantity Entered');

        }
      } else {
        alert('Invalid Quantity Entered');

      }

    } catch (e) {
      alert('Error occurred');
    }

    
  }

  editProduct(p: Product) {
    this.router.navigate(['/add-product',p])
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
    this.deleteSubscription?.unsubscribe();
    this.purchaseSubscription?.unsubscribe();
    this.saleSubs?.unsubscribe();
    }
  

}
