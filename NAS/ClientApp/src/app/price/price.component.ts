import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/data.service';
import { IHD_Price } from '../shared/HD_Price';
import { INAS_Price } from '../shared/NAS_Price';
import { ActivatedRoute, Router } from '@angular/router';
import { IBasicCost } from '../shared/BasicCost';
import { IComision } from '../shared/Comision';
@Component({
  selector: 'app-price',
  templateUrl: './price.component.html',
  styleUrls: ['./price.component.css']
})
export class PriceComponent implements OnInit {

  nases: INAS_Price[] = [];
  BasicCosts: IBasicCost[] = [];
  Comision: IComision[] = [];

  errorMessage: string;
  //nas: INAS_Price;
  constructor(public data: DataService, private route: ActivatedRoute,
    private router: Router) { }


  getnas(nas: INAS_Price) {
    this.data.nas = nas;
    this.router.navigate(['/hd-price']);
    // redirect to HardDrives
  }


  ngOnInit() {
    this.data.getNAS().subscribe({
      next: n => this.nases = n,
      error: e => this.errorMessage = e
    })
  }
 
}
