import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MovieListViewComponent } from './components/movie-list-view/movie-list-view.component';


const routes: Routes = [
  { path: 'movies', component: MovieListViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MovieRoutingModule { }
