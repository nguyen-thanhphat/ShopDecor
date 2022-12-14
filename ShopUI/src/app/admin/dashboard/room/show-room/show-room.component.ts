import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiserviceService } from '../../apiservice.service';

@Component({
  selector: 'app-show-room',
  templateUrl: './show-room.component.html',
  styleUrls: ['./show-room.component.css']
})
export class ShowRoomComponent implements OnInit{

  roomList$!:Observable<any[]>;

  constructor(private service: ApiserviceService) {}

  ngOnInit(): void {
    this.roomList$ = this.service.getRoomList();
  }

  //Biến
  modalTitle:string = '';
  activateAddEditRoomComponent:boolean =false;
  room:any;

  modalAdd(){
    this.room = {
      id:0,
      roomName:null
    }
    this.modalTitle = 'Thêm loại phòng!';
    this.activateAddEditRoomComponent = true;
  }
  modalEdit(item:any){
    this.room = item;
    this.modalTitle = "Cập nhật loại phòng!";
    this.activateAddEditRoomComponent = true;
  }

  delete(item: any){
    if(confirm(`Bạn có chắc muốn xoá ${item.id}`)){
      this.service.deleteRoom(item.id).subscribe(res => {
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
      this.roomList$ = this.service.getRoomList();
      })
    }
  }

  modalClose(){
    this.activateAddEditRoomComponent = false;
    this.roomList$ = this.service.getRoomList();
  }
}
