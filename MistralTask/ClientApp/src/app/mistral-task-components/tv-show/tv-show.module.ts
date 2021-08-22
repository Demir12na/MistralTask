import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TvShowRoutingModule } from './tv-show-routing.module';
import { TvShowListViewComponent } from './components/tv-show-list-view/tv-show-list-view.component';


@NgModule({
  declarations: [TvShowListViewComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    TvShowRoutingModule
  ]
})
export class TvShowModule { }
