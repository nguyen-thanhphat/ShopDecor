import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { OfferComponent } from './offer/offer.component';
import { CategoryComponent } from './category/category.component';
import { RoomComponent } from './room/room.component';
import { PaymentMethodsComponent } from './payment-methods/payment-methods.component';
import { ProductsComponent } from './products/products.component';

const DashboardRouter : Routes = [
  {
    path:'', component:DashboardComponent,
    children:[
      {
        path:'quan-tri',
        component: DashboardComponent
      },
      {
        path:'danh-muc',
        component: CategoryComponent
      },
      {
        path:'giam-gia',
        component: OfferComponent
      },
      {
        path:'loai-phong',
        component: RoomComponent
      },
      {
        path:'san-pham',
        component: ProductsComponent
      }
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
    CommonModule,
    RouterModule.forChild(DashboardRouter)
  ]
})
export class DashboardModule { }
