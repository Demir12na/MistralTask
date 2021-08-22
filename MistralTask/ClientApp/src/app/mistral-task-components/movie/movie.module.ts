import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgImageSliderModule } from 'ng-image-slider';

import { MovieRoutingModule } from './movie-routing.module';
import { MovieListViewComponent } from './components/movie-list-view/movie-list-view.component';

@NgModule({
  declarations: [
    MovieListViewComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgImageSliderModule,
    MovieRoutingModule
  ]
})

export class MovieModule { }
