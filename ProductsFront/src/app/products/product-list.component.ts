import { Component, OnInit } from '@angular/core';
import { IProduct } from './product';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public pageTitle: string = "MS Product List";
  public _filterBy: string = "";
  get filterBy(): string {
    return this._filterBy;
  }
  set filterBy(value: string) {
      this._filterBy = value;
      this.filterProducts = this.filterBy ? this.performFilter(this.filterBy) : this.products;
  }
  public products: IProduct[] = [];
  public filterProducts: IProduct[] = [];
  public errorMessage: string = "";
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
      this.getProducts();
  }
  getProducts(): void {
    this.productService.getProducts().subscribe({
      next: products => {
        this.products = products;
        this.filterProducts = this.products
      }
  });
  }
  performFilter(filterBy: string): IProduct[] {        
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter((product: IProduct) => product.productName.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }
  deleteProduct(productId: number): void{
    if(confirm("Do you want to delete Product?")){
      this.productService.deleteProduct(productId).subscribe({
        next: () => {
          this.getProducts();
        }
      });
    }
  }
}
