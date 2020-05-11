import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { IProduct, Product } from '../product';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  public addProductForm: FormGroup;
  public product: Product;
  constructor(private productService: ProductService,private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.addProductForm = new FormGroup({
      productName: new FormControl(""),
      price: new FormControl(""),
      description: new FormControl("")
    });
  }
  addProduct(): void {
    this.product = new Product();
    this.product.productName = this.addProductForm.get('productName').value;
    this.product.price = this.addProductForm.get('price').value;
    this.product.description = this.addProductForm.get('description').value;
    this.productService.addProduct(this.product).subscribe({
      next: (data) => {
        alert('Success added new product!');
        this.router.navigate(['/products']);
      }
    })
  }

}
