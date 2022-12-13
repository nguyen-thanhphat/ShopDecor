import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { Routes } from '@angular/router';
import { OfferComponent } from './offer/offer.component';
import { CategoryComponent } from './category/category.component';
import { RoomComponent } from './room/room.component';
import { PaymentMethodsComponent } from './payment-methods/payment-methods.component';
import { ProductsComponent } from './products/products.component';

const DashboardModulerouter : Routes = [
  {
    path:'', component:DashboardComponent,
    children:[
      
    ]
  }
]

@NgModule({
  declarations: [
    DashboardComponent,
    OfferComponent,
    CategoryComponent,
    RoomComponent,
    PaymentMethodsComponent,
    ProductsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DashboardModule { }
