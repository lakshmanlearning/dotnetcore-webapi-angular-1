import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MembersService } from './shared/services/members/members.service';
import { BaseService } from './shared/services/base/base.service';
import { CommonService } from './shared/services/common/common.service';
import { MyValuesComponent } from './my-values/my-values.component';
import { APP_BASE_HREF, HashLocationStrategy, LocationStrategy } from '@angular/common';

const routes: Routes = [
  { path: '', redirectTo: 'app', pathMatch: 'full' },
  //{ path: '', component: MyValuesComponent, pathMatch: 'full' },
  { path: 'app', component: MyValuesComponent },
  { path: 'home', component: HomeComponent },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'my-values', component: MyValuesComponent },
]

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MyValuesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes, { useHash: true })
    //RouterModule.forRoot(routes)
  ],
  providers: [
    //{ provide: APP_BASE_HREF, useValue: '/app' },
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    BaseService,
    MembersService,
    CommonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
