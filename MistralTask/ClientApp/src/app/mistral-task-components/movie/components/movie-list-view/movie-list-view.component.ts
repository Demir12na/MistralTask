import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { MovieGetListResItem } from '../../models/movie-get-list-res-item';
import { MovieApiService } from '../../services/movie-api.service';

@Component({
  selector: 'app-movie-list-view',
  templateUrl: './movie-list-view.component.html',
  styleUrls: ['./movie-list-view.component.css']
})

export class MovieListViewComponent implements OnInit {

  public loaded: boolean = false;
  public movies: Array<MovieGetListResItem> = [];
  private _formSubmitet: boolean = false;
  private _filters: any;
  private _searchByTerm: string = "";
  public counter : number = 10;

  constructor(private _movieApi: MovieApiService,
    private _formBuilder: FormBuilder,) { }

  searchForm = this._formBuilder.group({
    searchByTerm: [null]
  });

  ngOnInit() {
    this.refreshList();
  }

  refreshList() {

    if (this._formSubmitet) {

      this._filters = this.searchForm.get('searchByTerm').value;
    }
    else {
      this._filters = "";
    }

    this._movieApi.getList(this._filters).subscribe(data => {
      data.forEach(item => {
        this.movies.push(item);
      })
      this.loaded = true;
    });
  }

  onSubmit() {
    this._searchByTerm = this.searchForm.get('searchByTerm').value;
    if (this._searchByTerm == "") {
      this._formSubmitet = true;
      this.movies = [];
      this.refreshList();
    }
    if (this._searchByTerm.length > 2) {
      this._formSubmitet = true;
      this.movies = [];
      this.refreshList();
    }
  }

  showMore(){
    this.counter +=10;
  }

}
