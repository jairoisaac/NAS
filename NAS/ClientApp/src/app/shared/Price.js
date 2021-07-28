"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PriceHardDrives = exports.Price = void 0;
var _ = require("lodash");
var Price = /** @class */ (function () {
    function Price() {
        this.hds = new Array();
    }
    Object.defineProperty(Price.prototype, "subTotalCost", {
        get: function () {
            return this.nasCost + this.basic1 + this.basic2;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Price.prototype, "grandTotalCost", {
        get: function () {
            return this.subTotalCost + this.basic3;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Price.prototype, "hardDiskConfiguration", {
        get: function () {
            return _.sum(_.map(this.hds, function (h) { return h.amount * h.cost; }));
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Price.prototype, "subCost", {
        get: function () {
            return this.hardDiskConfiguration + this.grandTotalCost;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Price.prototype, "salesMargin", {
        get: function () {
            return this.subCost * (this.comision1 + 1);
            //return this.subCost * this.comision1 + this.subCost
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Price.prototype, "creditCardCommission", {
        get: function () {
            return this.salesMargin * this.comision2;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Price.prototype, "grandTotal", {
        get: function () {
            return this.salesMargin + this.creditCardCommission;
        },
        enumerable: false,
        configurable: true
    });
    return Price;
}());
exports.Price = Price;
var PriceHardDrives = /** @class */ (function () {
    function PriceHardDrives() {
    }
    return PriceHardDrives;
}());
exports.PriceHardDrives = PriceHardDrives;
//# sourceMappingURL=Price.js.map