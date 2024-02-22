import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProductListComponent } from './product-list/product-list.component';
import { AddProductComponent } from './add-product/add-product.component';
import { PurchaseListComponent } from './purchase-list/purchase-list.component';
import { SaleListComponent } from './sale-list/sale-list.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProductListComponent,
    AddProductComponent,
    PurchaseListComponent,
    SaleListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([      
      { path: '', component: ProductListComponent, pathMatch: 'full' },
      { path: 'purchase-list', component: PurchaseListComponent },
      { path: 'sale-list', component: SaleListComponent },
      { path: 'add-product', component: AddProductComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
