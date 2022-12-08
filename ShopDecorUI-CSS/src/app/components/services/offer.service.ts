import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Offer } from '../models/offer';

@Injectable({
  providedIn: 'root'
})
export class OfferService {
  private url = 'Offer';
  constructor(private http: HttpClient) { }

  public getOffers():Observable<Offer[]>{
    return this.http.get<Offer[]>(`${environment.apiUrl}/${this.url + '/GetListOffer'}`)
  }

  public updateOffer(offer: Offer):Observable<Offer[]>{
    return this.http.put<Offer[]>(
      `${environment.apiUrl}/${this.url + '/UpdateOffer'}`,offer
    );
  }

  public createOffer(offer: Offer):Observable<Offer[]>{
    return this.http.post<Offer[]>(
      `${environment.apiUrl}/${this.url + '/CreateOffer'}`,
      offer
    );
  }

  public deleteOffer(offer: Offer):Observable<Offer[]>{
    return this.http.delete<Offer[]>(
      `${environment.apiUrl}/${this.url} + '/DeleteOffer/' + ${offer.id}`
    );
  }
}
