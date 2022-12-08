import { Component } from '@angular/core';
import { Offer } from '../../models/offer';
import { OfferService } from '../../services/offer.service';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent {
  title = 'Offer';
  offers: Offer[] = [];
  offerToEdit?: Offer;

  constructor(private offerService: OfferService) { }

  ngOnInit(): void {
    this.offerService
      .getOffers()
      .subscribe((result: Offer[]) => (this.offers = result));
  }

  updateOfferList(offers: Offer[]){
    this.offers = offers;
  }

  initNewOffer(){
    this.offerToEdit = new Offer();
  }

  editOffer(offer: Offer){
    this.offerToEdit = offer;
  }
}
