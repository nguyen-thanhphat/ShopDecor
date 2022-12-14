import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  readonly apiUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  //#region Offer
    getOfferList(): Observable<any[]>{
      return this.http.get<any[]>(this.apiUrl + `Offer/GetListOffer`);
    }

    addOffer(data: any){
      return this.http.post(this.apiUrl + `Offer/CreateOffer`, data);
    }

    updateOffer(id:number|string, data:any){
      return this.http.put(this.apiUrl + `Offer/UpdateOffer?offerId=${id}`, data);
    }

    deleteOffer(id:number|string){
      return this.http.delete(this.apiUrl + `Offer/DeleteOffer?offerId=${id}`);
    }
  //#endregion

  //#region Category
    getCategoryList(): Observable<any[]>{
      return this.http.get<any[]>(this.apiUrl + `Category/GetListCategories`);
    }

    addCategory(data: any){
      return this.http.post(this.apiUrl + `Category/CreateCategory`,data);
    }

    updateCategory(id:number|string, data:any){
      return this.http.put(this.apiUrl + `Category/UpdateCategory?categoryId=${id}`, data);
    }

    deleteCategory(id:number|string){
      return this.http.delete(this.apiUrl + `Category/DeleteCategory?categoryId=${id}`);
    }
  //#endregion

  //#region Room
    getRoomList(): Observable<any[]>{
      return this.http.get<any[]>(this.apiUrl + `Room/GetListRoom`);
    }

    addRoom(data: any){
      return this.http.post(this.apiUrl + `Room/CreateRoom`, data);
    }

    updateRoom(id:number|string, data:any){
      return this.http.put(this.apiUrl + `Room/UpdateRoom?roomId=${id}`, data);
    }

    deleteRoom(id:number|string){
      return this.http.delete(this.apiUrl + `Room/DeleteRoom?roomId=${id}`);
    }
  //#endregion

  //#region Products
    getProductList(): Observable<any[]>{
      return this.http.get<any[]>(this.apiUrl + `Product/GetListProduct`);
    }

    addProduct(data: any){
      return this.http.post(this.apiUrl + `Product/CreateProduct`, data);
    }

    updateProduct(id:number|string, data:any){
      return this.http.put(this.apiUrl + `Product/UpdateProduct?productId=${id}`, data);
    }

    deleteProduct(id:number|string){
      return this.http.delete(this.apiUrl + `Product/DeleteProduct?productId=${id}`);
    }
  //#endregion

  //#region Payment Method
    getPaymenthodList(): Observable<any[]>{
      return this.http.get<any[]>(this.apiUrl + `PayMethod/GetListPayMethod`);
    }

    addPaymentMethod(data: any){
      return this.http.post(this.apiUrl + `PayMethod/CreatePayMethod`, data);
    }

    updatePaymentMethod(id:number|string, data:any){
      return this.http.put(this.apiUrl + `PayMethod/UpdatePayMethod?payMethodId=${id}`, data);
    }

    deletePaymentMethod(id:number|string){
      return this.http.delete(this.apiUrl + `PayMethod/DeletePaymethod?payMethodId=${id}`);
    }
  //#endregion
}
