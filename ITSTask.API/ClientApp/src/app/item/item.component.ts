import { Component, OnInit } from "@angular/core";
import { ItemService } from "../service/item.service";
import { Item } from "../models/item";

@Component({
  selector: "app-item",
  templateUrl: "./item.component.html",
  styleUrls: ["./item.component.css"],
})
export class ItemComponent implements OnInit {
  model: Item = {
    id: 0,
    tittle: "",
    description: "",
  };
  itemsModel: Item[] = [];
  formHidden = true;
  constructor(private itemservice: ItemService) {
    this.getitems();
  }

  getitems() {
    this.itemservice.getItems().subscribe((data: Item[]) => {
      this.itemsModel = data;
    });
  }
  ngOnInit() {}

  add(){
    this.emptymodel();
    this.formHidden = false;
  }

  Save() {
    this.itemservice.Save(this.model).subscribe(this.itemObserver);
  }
 
  //observer 
  temp:Item;
  itemObserver = {
    next: (data: any) => {     
    this.temp = data;
  },
    error: (err: string) => console.error('Observer got an error: ' + err),
    complete: () => {
    if(this.model.id === 0 )
      {
        alert("added succsefully");
        this.itemsModel.push(this.temp)
      }
      else{
        alert("updated succsefully");
      }
      this.emptymodel();
     },
  };
  emptymodel() {
    this.model = {
      id: 0,
      tittle: "",
      description: "",
    };
  }
//end observer

  delete(id: Number) {    
    const index: number = this.itemsModel.findIndex((item) => item.id == id);
    if (index !== -1) {
      this.itemsModel.splice(index, 1);
    }   
    this.itemservice.delete(id).subscribe(() => {
      alert("deleted");
    });
  }

  update(itemupdate: Item) {
    this.formHidden = false;
    this.model = itemupdate;
  }
}
