import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { OfferComponent } from './offer/offer.component';
import { CategoryComponent } from './category/category.component';
import { RoomComponent } from './room/room.component';
import { PaymentMethodsComponent } from './payment-methods/payment-methods.component';
import { ProductsComponent } from './products/products.component';
import { AddEditOfferComponent } from './offer/add-edit-offer/add-edit-offer.component';
import { ShowOfferComponent } from './offer/show-offer/show-offer.component';
import { ApiserviceService } from './apiservice.service';
import { AppComponent } from 'src/app/app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddEditCategoryComponent } from './category/add-edit-category/add-edit-category.component';
import { ShowCategoryComponent } from './category/show-category/show-category.component';
import { ShowRoomComponent } from './room/show-room/show-room.component';
import { AddEditRoomComponent } from './room/add-edit-room/add-edit-room.component';
import { AddEditPamentMethodsComponent } from './payment-methods/add-edit-pament-methods/add-edit-pament-methods.component';
import { ShowPaymentMethodsComponent } from './payment-methods/show-payment-methods/show-payment-methods.component';
import { AddEditProductComponent } from './products/add-edit-product/add-edit-product.component';
import { ShowProductComponent } from './products/show-product/show-product.component';

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
      },
      {
        path:'loai-thanh-toan',
        component: PaymentMethodsComponent
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
    ProductsComponent,
    AddEditOfferComponent,
    ShowOfferComponent,
    AddEditCategoryComponent,
    ShowCategoryComponent,
    ShowRoomComponent,
    AddEditRoomComponent,
    AddEditPamentMethodsComponent,
    ShowPaymentMethodsComponent,
    AddEditProductComponent,
    ShowProductComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(DashboardRouter),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers:[ApiserviceService],
  bootstrap:[AppComponent]
})
export class DashboardModule { }
