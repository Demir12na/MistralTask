import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { TvShowGetListResItem } from '../../models/tv-show-get-list-res-item';
import { TvShowApiService } from '../../services/tv-show-api.service';

@Component({
  selector: 'app-tv-show-list-view',
  templateUrl: './tv-show-list-view.component.html',
  styleUrls: ['./tv-show-list-view.component.css']
})
export class TvShowListViewComponent implements OnInit {

  public loaded: boolean = false;
  public tvShows: Array<TvShowGetListResItem> = [];
  private _formSubmitet: boolean = false;
  private _filters: any;
  private _searchByTerm: string = "";
  private _counter : number = 10;

  constructor(
    private _tvShowApi: TvShowApiService,
    private _formBuilder: FormBuilder
  ) { }

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

    this._tvShowApi.getList(this._filters).subscribe(data => {
      data.forEach(item => {
        this.tvShows.push(item);
      })

      data.forEach(function(value, index){
        if(this._counter>index){
          this.tvShows.push(value);
        }
      })
      this.loaded = true;
    });
  }

  onSubmit() {
    this._searchByTerm = this.searchForm.get('searchByTerm').value;
    if (this._searchByTerm == "") {
      this._formSubmitet = true;
      this.tvShows = [];
      this.refreshList();
    }
    if (this._searchByTerm.length > 2) {
      this._formSubmitet = true;
      this.tvShows = [];
      this.refreshList();
    }
  }

}
