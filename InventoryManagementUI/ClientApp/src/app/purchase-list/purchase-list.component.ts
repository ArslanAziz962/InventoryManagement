import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Purchase } from '../../models/Purchase';
import { PurchaseService } from '../../services/purchase/purchase.service';

@Component({
  selector: 'app-purchase-list',
  templateUrl: './purchase-list.component.html',
  styleUrls: ['./purchase-list.component.css']
})
export class PurchaseListComponent implements OnDestroy {

  purchases: Purchase[];
  subscription?: Subscription;  
  isError: boolean;
  isLoading: boolean = true;

  constructor(private purchaseSerivce: PurchaseService) {
    this.purchases = []
    this.isError = false;
    this.getAllPurchases();
  }
  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
    }

  getAllPurchases() {

    this.subscription = this.purchaseSerivce.getAllPurchases().subscribe({
      next: (response) => {
        console.log('purchases:', response);
        this.purchases = response
        this.isLoading = false;
      },
      error: (error) => {
        this.isError = true;
        this.isLoading = false;

        console.error('error when getting products:', error)
      }
    })


  }


}
