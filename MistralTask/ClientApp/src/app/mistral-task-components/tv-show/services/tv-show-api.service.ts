import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TvShowGetListResItem } from '../models/tv-show-get-list-res-item';

@Injectable({
  providedIn: 'root'
})

export class TvShowApiService {

  private _url: string = '/api/tv-shows';
  constructor(private _http: HttpClient) { }

  getList(req: TvShowGetListResItem) {
    return this._http.get<Array<TvShowGetListResItem>>(this._url + '?searchByTerm=' + req);
  }
}
