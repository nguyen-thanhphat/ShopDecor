import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

const appRoute: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./user/homepage/homepage.module').then((m) => m.HomepageModule)
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./admin/dashboard/dashboard.module').then((m) => m.DashboardModule),
  },
];
@NgModule({
  declarations: [AppComponent, ],
  imports: [
    BrowserModule, 
    AppRoutingModule,
    RouterModule.forRoot(appRoute),
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
