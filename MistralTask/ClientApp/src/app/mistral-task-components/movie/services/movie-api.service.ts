import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { MovieAddRatingReq } from '../models/movie-add-rating-req';
import { MovieAddRatingRes } from '../models/movie-add-rating-res';
import { MovieGetListResItem } from '../models/movie-get-list-res-item';

@Injectable({
  providedIn: 'root'
})
export class MovieApiService {

  private _url: string = '/api/movies';
  constructor(private _http: HttpClient) { }

  getList(req: MovieGetListResItem) {
    return this._http.get<Array<MovieGetListResItem>>(this._url + '?searchByTerm=' + req);
  }
  
  addRating(req: MovieAddRatingReq) {
    return this._http.post<MovieAddRatingRes>(this._url, req)
  }

}
