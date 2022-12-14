import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiserviceService } from '../../apiservice.service';

@Component({
  selector: 'app-show-payment-methods',
  templateUrl: './show-payment-methods.component.html',
  styleUrls: ['./show-payment-methods.component.css']
})
export class ShowPaymentMethodsComponent implements OnInit{

  paymentMethodsList$!:Observable<any[]>;

  constructor(private service:ApiserviceService){}

  ngOnInit(): void {
    this.paymentMethodsList$ = this.service.getPaymenthodList();
  }

  modalTitle:string = '';
  activateAddEditPayMethodsComponent: boolean = false;
  paymentMethod:any;

  modalAdd(){
    this.paymentMethod = {
      id:0,
      payType:null,
      payProvider:null,
      payReason:null,
      Available:null
    }
    this.modalTitle = "Thêm phương thức thanh toán!";
    this.activateAddEditPayMethodsComponent = true;
  }

  modalEdit(item:any){
    this.paymentMethod = item;
    this.modalTitle = "Cập nhật phương thức thanh toán!";
    this.activateAddEditPayMethodsComponent = true;
  }

  delete(item: any){
    if(confirm(`Bạn có chắc muốn xoá ${item.id}`)){
      this.service.deletePaymentMethod(item.id).subscribe(res => {
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
      this.paymentMethodsList$ = this.service.getPaymenthodList();
      })
    }
  }

  modalClose(){
    this.activateAddEditPayMethodsComponent = false;
    this.paymentMethodsList$ = this.service.getPaymenthodList();
  }
}
