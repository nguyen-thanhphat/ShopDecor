import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';

const appRoute: Routes = [
  {
    path: 'homepage',
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
    RouterModule.forRoot(appRoute)
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
