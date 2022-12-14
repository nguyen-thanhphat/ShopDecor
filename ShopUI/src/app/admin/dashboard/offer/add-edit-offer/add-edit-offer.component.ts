import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiserviceService } from '../../apiservice.service';

@Component({
  selector: 'app-add-edit-offer',
  templateUrl: './add-edit-offer.component.html',
  styleUrls: ['./add-edit-offer.component.css']
})
export class AddEditOfferComponent implements OnInit {

  offerList$!:Observable<any[]>;

  constructor(private service: ApiserviceService) {}

  @Input() offer:any;
  id: number = 0;
  title:string = "";
  discount: string = "";

  ngOnInit(): void {
    this.id = this.offer.id;
    this.title = this.offer.title;
    this.discount = this.offer.discount;
  }

  addOffer(){
    var offer = {
      title:this.title,
      discount:this.discount
    }
    this.service.addOffer(offer).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-success-alert');
      if(showAddSuccess){
        showAddSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showAddSuccess){
          showAddSuccess.style.display = "none"
        }
      }, 4000);
    })
  }

  updateOffer(){
    var offer = {
      id: this.id,
      titel:this.title,
      discount:this.discount
    }
    var id:number = this.id;
    this.service.updateOffer(id,offer).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
      if(showUpdateSuccess){
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showUpdateSuccess){
          showUpdateSuccess.style.display = "none"
        }
      }, 4000);
    })
  }
}
