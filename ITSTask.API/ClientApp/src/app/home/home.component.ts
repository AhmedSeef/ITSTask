import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from '../models/item';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  steps = ['step2', 'step3'];
  constructor(private router:Router) {
    this.router.navigate(['/item']);
   }

  ngOnInit() {
  }

  addStep(){    
    this.steps.push("new step");
  }

  removeStep(step:string){
    const index: number = this.steps.indexOf(step);
    if (index !== -1) {
        this.steps.splice(index, 1);
    } 
  }

  
}
