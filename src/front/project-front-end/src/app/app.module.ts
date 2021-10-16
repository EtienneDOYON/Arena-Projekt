import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';

import { Routes } from '@angular/router';
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
import { MatTableModule } from '@angular/material/table'

import { ClassList } from './admin/class/class_list/class_list.component';
import { ClassAdd } from './admin/class/class_add/class_add.component';
import { ClassEdit } from './admin/class/class_edit/class_edit.component';

import { SubclassList } from './admin/subclass/subclass_list/subclass_list.component';
import { SubclassAdd } from './admin/subclass/subclass_add/subclass_add.component';
import { MatSelectModule } from '@angular/material/select';
import { SubclassEdit } from './admin/subclass/subclass_edit/subclass_edit.component';

const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'users', component: UsersComponent},
  {path: 'notFound', component: NotFoundComponent},
  {path: 'notAllowed', component: NotAllowedComponent},
  {path: 'team_warriors', component: TeamWarriors},

  {path: 'class_list', component: ClassList},
  {path: 'class_add', component: ClassAdd},
  {path: 'class_edit/:id', component: ClassEdit},

  {path: 'subclass_list', component: SubclassList},
  {path: 'subclass_add', component: SubclassAdd},
  {path: 'subclass_edit/:id', component: SubclassEdit},

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
    ClassAdd,
    ClassEdit,

    SubclassList,
    SubclassAdd,
    SubclassEdit
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatTableModule,
    MatSelectModule,
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