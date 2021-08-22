import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TvShowListViewComponent } from './components/tv-show-list-view/tv-show-list-view.component';

const routes: Routes = [
  { path: 'tv-shows', component: TvShowListViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TvShowRoutingModule { }
