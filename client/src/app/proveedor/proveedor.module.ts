import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  proveedorComponent } from './proveedor.component';
import { SharedModule } from '../shared/shared.module';
import { ProveedorRoutingModule } from './proveedor-routing.module';
import { DetalleItemComponent } from './detalle-item/detalle-item.component';
import { AgregarEditarComponent } from './agregar-editar/agregar-editar.component';



@NgModule({
  declarations: [
    proveedorComponent,
    DetalleItemComponent,
    AgregarEditarComponent
  ],
  imports: [
    CommonModule,
    ProveedorRoutingModule,
    SharedModule
  ]
})
export class proveedorModule { }