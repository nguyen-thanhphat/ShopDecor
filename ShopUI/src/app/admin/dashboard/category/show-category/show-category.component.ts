import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiserviceService } from '../../apiservice.service';

@Component({
  selector: 'app-show-category',
  templateUrl: './show-category.component.html',
  styleUrls: ['./show-category.component.css']
})
export class ShowCategoryComponent implements OnInit{

  categoryList$!:Observable<any[]>;

  constructor(private service:ApiserviceService) {}

  ngOnInit(): void {
    this.categoryList$ = this.service.getCategoryList();
  }

  modalTitle:string = '';
  activateAddEditCategoryComponent: boolean = false;
  category:any;

  modalAdd(){
    this.category = {
      id:0,
      categoryName:null,
      subCategory:null
    }
    this.modalTitle = "Thêm danh mục sản phẩm!";
    this.activateAddEditCategoryComponent = true;
  }

  modalEdit(item:any){
    this.category = item;
    this.modalTitle = "Cập nhật danh mục sản phẩm!";
    this.activateAddEditCategoryComponent = true;
  }

  delete(item:any){
    if(confirm(`Bạn có chắc muốn xoá ${item.id}`)){
      this.service.deleteCategory(item.id).subscribe(res => {
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
      this.categoryList$ = this.service.getOfferList();
      })
    }
  }

  modalClose(){
    this.activateAddEditCategoryComponent = false;
    this.categoryList$ = this.service.getCategoryList();
  }
}

