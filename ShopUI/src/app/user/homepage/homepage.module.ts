import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomepageComponent } from './homepage.component';
import { Routes } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsComponent } from './products/products.component';
import { SuggestedProductsComponent } from './suggested-products/suggested-products.component';

const HomepageComponentrouter : Routes = [
  {
    path:'', component:HomepageComponent,
    children:[
      
    ]
  }
]

@NgModule({
  declarations: [
    HomepageComponent,
    CartComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    OrderComponent,
    PageNotFoundComponent,
    ProductComponent,
    ProductDetailsComponent,
    ProductsComponent,
    SuggestedProductsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HomepageModule { }
