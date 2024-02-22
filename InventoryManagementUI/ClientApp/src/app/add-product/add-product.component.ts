import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from '../../models/Product';
import { Purchase } from '../../models/Purchase';
import { Sale } from '../../models/Sale';
import { ProductService } from '../../services/product/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnDestroy, OnInit {


  model: Product;
  addProductSubscription?: Subscription;
  updateProductSubscription?: Subscription;
  isEditMode: boolean;

  message: string;
  errorMessage: string;
  constructor(private productService: ProductService, private activatedRoute: ActivatedRoute) {
    this.model = {
      name: '',
      description: '',
      quantity: 0,
      price: 0,
      productId: 0,
      purchases: [],
      sales: []
    };
    this.message = '';
    this.errorMessage = '';
    this.isEditMode = false;
  }
  ngOnInit(): void {
    var paramProduct = this.activatedRoute.snapshot.params;

    if (paramProduct.name) {
      this.model.name = paramProduct.name;
      this.model.description = paramProduct.description;
      this.model.quantity = paramProduct.quantity;
      this.model.price = paramProduct.price;
      this.model.productId = paramProduct.productId;

      this.isEditMode = true;
    }

    }
  ngOnDestroy(): void {
    this.addProductSubscription?.unsubscribe();
    this.updateProductSubscription?.unsubscribe();
    }

  onFormSubmit() {
    this.errorMessage = '';
    this.message = '';

    if (this.model.name === '' || this.model.description === '' || this.model.quantity <= 0 || this.model.price <= 0) {
      this.errorMessage = 'Enter valid data first';


    } else {

      console.log(this.model)

      if (this.isEditMode) {
        //alert('edit mode')
        this.updateProductSubscription = this.productService.updateProduct(this.model.productId.toString(), this.model)
          .subscribe({
            next: (response) => {
              this.message = 'data updated successfully';
              console.log('updated:', response);
            },
            error: (error) => {
              console.error('error :', error);

              this.errorMessage = 'Faild to update data';

            }
          })


      } else {
        this.addProductSubscription = this.productService.addProduct(this.model).subscribe({
          next: (response) => {
            console.log('product added ', response);
            this.message = 'Product Added successfully';
          },
          error: (error) => {
            console.error('error when adding product', error);
            this.errorMessage = 'Error when adding Product';

          }
        })
      }

      
    }


  }
}
