import { Component, OnInit } from '@angular/core';
import { IBasicCost } from '../shared/BasicCost';
import { DataService } from '../shared/data.service';
import { IComision } from '../shared/Comision';
import { Price } from '../shared/Price';
import { forEach } from 'lodash';
@Component({
  selector: 'app-totl-price',
  templateUrl: './totl-price.component.html',
  styleUrls: ['./totl-price.component.css']
})
export class TotlPriceComponent implements OnInit {
  constructor(public data: DataService) { }
  errorMessage = "";
  basicCosts: IBasicCost[] = [];
  comisions: IComision[] = [];

  totalPrice: Price = new Price;

  fillTotalPrice() {
    this.totalPrice.basic1 = this.basicCosts[0].value;
    this.totalPrice.basic2 = this.basicCosts[1].value;
    this.totalPrice.basic3 = this.basicCosts[2].value;
    this.totalPrice.comision1 = this.comisions[0].value;
    this.totalPrice.comision2 = this.comisions[1].value;
    this.totalPrice.nasCost = this.data.nas.cost;
    this.totalPrice.sku = this.data.nas.sku;
    this.totalPrice.id = this.data.nas.id;
    for (var i = 0; i < this.data.hdsPrice.length; i++) {
      this.totalPrice.hds.push(this.data.hdsPrice[i]);
    }
  }
  //ngAfterViewChecked() {
  //  this.fillTotalPrice();
  //}
  ngOnInit() {
    this.data.getBasicCosts().subscribe({
      next: b => this.basicCosts = b,
      error: e => this.errorMessage = e,
      complete: () => {
        this.data.getComision().subscribe({
          next: c => this.comisions = c,
          error: e => this.errorMessage = e,
          complete: () => {
            this.fillTotalPrice();
          }
        })
      }
    })
  }

}
