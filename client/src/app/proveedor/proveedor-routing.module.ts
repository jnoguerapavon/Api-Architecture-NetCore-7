import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { proveedorComponent } from './proveedor.component';
import { DetalleItemComponent } from './detalle-item/detalle-item.component';
import { AgregarEditarComponent } from './agregar-editar/agregar-editar.component';

const routes: Routes = [
  {path: '', component: proveedorComponent},
  { path: 'ver/:id', component: DetalleItemComponent },
  { path: 'editar/:id', component: AgregarEditarComponent },
  { path: 'agregar', component: AgregarEditarComponent },
  
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ProveedorRoutingModule { }
