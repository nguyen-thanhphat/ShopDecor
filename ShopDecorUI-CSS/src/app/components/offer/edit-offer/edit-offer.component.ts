import { Component,EventEmitter,Input, OnInit,Output } from '@angular/core';
import { Offer } from '../../models/offer';
import { OfferService } from '../../services/offer.service';

@Component({
  selector: 'app-edit-offer',
  templateUrl: './edit-offer.component.html',
  styleUrls: ['./edit-offer.component.css']
})
export class EditOfferComponent implements OnInit {
  @Input() offer?: Offer;
  @Output() offersUpdated = new EventEmitter<Offer[]>();

  constructor(private offerService: OfferService) { }

  ngOnInit(): void {
  }

  updateOffer(offer: Offer){
    this.offerService
      .deleteOffer(offer)
      .subscribe((offers: Offer[]) => this.offersUpdated.emit(offers));
  }

  deleteOffer(offer: Offer) {
    this.offerService
      .deleteOffer(offer)
      .subscribe((offers: Offer[]) => this.offersUpdated.emit(offers));
  }

  createOffer(offer: Offer) {
    this.offerService
      .createOffer(offer)
      .subscribe((offers: Offer[]) => this.offersUpdated.emit(offers));
  }
}
