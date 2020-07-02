import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/item';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

basurl = "https://localhost:44386/api/item/";
constructor(private http:HttpClient) { }

getItems(){
  return this.http.get(this.basurl + "getAllItems")
}

Save(item:Item){
  return this.http.post(this.basurl + "AddOrUpdate",item)
}

delete(id:Number){
  return this.http.delete(this.basurl + "Delete/"+id)
}
}
