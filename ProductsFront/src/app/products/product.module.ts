import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductAddComponent } from './product-add/product-add.component';



@NgModule({
  declarations: [
    ProductListComponent,
    ProductEditComponent,
    ProductAddComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'products', component: ProductListComponent},
      { path: 'product-edit/:id', component: ProductEditComponent},
      { path: 'product-add', component: ProductAddComponent}
    ])
  ]
})
export class ProductModule { }
