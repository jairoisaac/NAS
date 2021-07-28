import * as _ from "lodash";
export class Price {
  id: number;
  sku: string;  //This is the SKU of the WholeProduct.
  nasId: number;
  nasCost: number; 
  basic1: number;  // fields coming from basicCost table database
  basic2: number; // fields coming from basicCost table database
  get subTotalCost(): number {
    return this.nasCost + this.basic1 + this.basic2;
  }
  basic3: number; // fields coming from basicCost table database
  get grandTotalCost(): number {
    return this.subTotalCost + this.basic3
  }
  get hardDiskConfiguration(): number {
    return _.sum(_.map(this.hds, h => h.amount * h.cost))
  }
  get subCost(): number {
    return this.hardDiskConfiguration + this.grandTotalCost
  }
  comision1: number; // fields coming from comision table database 
  comision2: number; // fields coming from comision table database

  get salesMargin(): number {
    return this.subCost * (this.comision1 + 1)
    //return this.subCost * this.comision1 + this.subCost
  }
  get creditCardCommission(): number {
    return this.salesMargin * this.comision2;
  }
  get grandTotal(): number {
    return this.salesMargin + this.creditCardCommission;
  }
  hds: Array<PriceHardDrives> = new Array<PriceHardDrives>();
}
export class PriceHardDrives {
  id: number;
  sku: string;
  cost: number;
  amount: number;
}
