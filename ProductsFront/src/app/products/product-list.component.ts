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
  public filterBy: string = "";
  public products: IProduct[] = [];
  public errorMessage: string = "";
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
      this.productService.getProducts().subscribe({
          next: products => {
            this.products = products;
          }
      });
  }

}
