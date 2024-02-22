import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Sale } from '../../models/Sale';
import { SaleService } from '../../services/sale/sale.service';

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['./sale-list.component.css']
})
export class SaleListComponent implements OnDestroy {

  sales: Sale[];
  subscription?: Subscription;
  isError: boolean;
  isLoading: boolean = true;

  constructor(private saleSerivce: SaleService) {
    this.sales = []
    this.isError = false;
    this.getAllSales();
  }
  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  getAllSales() {

    this.subscription = this.saleSerivce.getAllSales().subscribe({
      next: (response) => {
        console.log('sales:', response);
        this.sales = response
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
