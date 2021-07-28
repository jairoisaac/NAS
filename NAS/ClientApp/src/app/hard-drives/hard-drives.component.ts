import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/data.service';
import { IHD_Price } from '../shared/HD_Price';
import { INAS_Price } from '../shared/NAS_Price';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-hard-drives',
  templateUrl: './hard-drives.component.html',
  styleUrls: ['./hard-drives.component.css']
})
export class HardDrivesComponent implements OnInit {
  hds: IHD_Price[] = [];
  myNAS: INAS_Price;
  errorMessage = "";
  constructor(public data: DataService, private route: ActivatedRoute,
    private router: Router) { }

  gethds(hd: IHD_Price) {
    // Save the hard drives chosen
    this.data.hdsPrice.push(hd);
    // Search ffor hd on hds.
    var indexHD = this.hds.findIndex(i => i.id = hd.id);
    this.hds.splice(indexHD, 1);
    // erase it from hds.
    // Should erase the one chosen
    
  };

  productready() {
    this.router.navigate(['/product']);
    // Redirect To ProductReady component
  }
  ngOnInit() {
    this.data.getHD().subscribe({
      next: h => this.hds = h,
      error: e => this.errorMessage = e
    })
    this.myNAS = this.data.nas;
  }

}
