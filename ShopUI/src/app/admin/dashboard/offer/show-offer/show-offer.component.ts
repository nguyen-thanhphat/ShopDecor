import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiserviceService } from '../../apiservice.service';


@Component({
  selector: 'app-show-offer',
  templateUrl: './show-offer.component.html',
  styleUrls: ['./show-offer.component.css']
})
export class ShowOfferComponent implements OnInit{

  offerList$!:Observable<any[]>;

  constructor(private service: ApiserviceService) {}

  ngOnInit(): void {
    this.offerList$ = this.service.getOfferList();
  }

  //Biến
  modalTitle:string = '';
  activateAddEditOfferComponent: boolean = false;
  offer:any;

  modalAdd(){
    this.offer = {
      id:0,
      offerTitle:null,
      offerDiscount:null
    }
    this.modalTitle = "Thêm khuyển mại!";
    this.activateAddEditOfferComponent = true;
  }

  modalEdit(item:any){
    this.offer = item;
    this.modalTitle = "Cập nhật khuyến mại!";
    this.activateAddEditOfferComponent = true;
  }

  delete(item: any){
    if(confirm(`Bạn có chắc muốn xoá ${item.id}`)){
      this.service.deleteOffer(item.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showDeleteSuccess = document.getElementById('delete-success-alert');
      if(showDeleteSuccess){
        showDeleteSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showDeleteSuccess){
          showDeleteSuccess.style.display = "none"
        }
      }, 4000);
      this.offerList$ = this.service.getOfferList();
      })
    }
  }

  modalClose(){
    this.activateAddEditOfferComponent = false;
    this.offerList$ = this.service.getOfferList();
  }

  
}
