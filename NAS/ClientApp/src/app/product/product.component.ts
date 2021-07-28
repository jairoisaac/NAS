import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/data.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(public data: DataService, private route: ActivatedRoute,
    private router: Router) { }

  errorMessage = "";

  public itemToDecrese(item) {
    if (item.amount > 1) {
      this.errorMessage = "";
      item.amount = item.amount - 1
      //alert("Id " + item.productId + " Quantity " + item.amount);
    } else if (item.amount === 1) {
      this.errorMessage = "Cannot be errased";
      // delete that index
      //var myIndex = this.data.hdsPrice.findIndex(i => i.id == item.id);
      //this.data.hdsPrice.splice(myIndex, 1);
      //alert(" Index " + myIndex);
    }
  }
  public itemToIncrease(item) {
    item.amount = item.amount + 1;
  }
  public ItemToDelete(item) {

    // delete that index
    var myIndex = this.data.hdsPrice.findIndex(i => i.id == item.id);
    this.data.hdsPrice.splice(myIndex, 1)
  }

  totalPrice() {
    this.router.navigate(['/total-price']);
  }
  ngOnInit() { 
    }
}
