import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { IProduct } from '../product';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  public product: IProduct;
  public editProductForm: FormGroup;
  constructor(private route: ActivatedRoute, private router: Router, private productService:ProductService) {
    this.product.productName = '';
    this.product.price = 0.0;
    this.product.description = '';
  }

  ngOnInit(): void {
    let id: number = +this.route.snapshot.paramMap.get('id');
    this.productService.getProductById(id).subscribe({
      next: data => {
        this.product = data;
        this.editProductForm = new FormGroup({
          id: new FormControl(this.product.id),
          productName: new FormControl(this.product.productName),
          price: new FormControl(this.product.price),
          description: new FormControl(this.product.description)
        });
      }
    });
  }

  editProduct(): void {
    this.product.id = this.editProductForm.get('id').value;
    this.product.productName = this.editProductForm.get('productName').value;
    this.product.price = this.editProductForm.get('price').value;
    this.product.description = this.editProductForm.get('description').value;
    this.productService.updateProduct(this.product.id, this.product).subscribe({
      next: () => {
        console.log('Success edit');
        alert('Success edit product!');
      }
    })
  }
}
