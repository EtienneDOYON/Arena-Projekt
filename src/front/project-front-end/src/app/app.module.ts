import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ClassList } from './admin/class/class_list/class_list.component';
import { UsersComponent } from './users/users.component';

import {Routes} from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { NotAllowedComponent } from './not-allowed/not-allowed.component';
import { TeamWarriors } from './team/team_warriors/team-warriors.component';

import { RouterModule } from '@angular/router';

import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {HttpClient, HttpClientModule} from '@angular/common/http';

import {MatMenuModule} from '@angular/material/menu';

import { FormsModule } from '@angular/forms';

import { ToastrModule } from 'ngx-toastr';
import { ClassAdd } from './admin/class/class_add/class_add.component';

const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'users', component: UsersComponent},
  {path: 'notFound', component: NotFoundComponent},
  {path: 'notAllowed', component: NotAllowedComponent},
  {path: 'team_warriors', component: TeamWarriors},

  {path: 'class_list', component: ClassList},
  {path: 'class_add', component: ClassAdd},

  {path: '**', redirectTo: '/notFound', pathMatch: 'full'}
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UsersComponent,
    NotFoundComponent,
    NotAllowedComponent,
    TeamWarriors,
    ClassList,
    ClassAdd
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    BrowserAnimationsModule,
    MatMenuModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}