import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Proveedor } from 'src/app/shared/models/proveedor';
import { ShopService } from 'src/app/shop/shop.service';

@Component({
  selector: 'app-agregar-editar',
  templateUrl: './agregar-editar.component.html',
  styleUrls: ['./agregar-editar.component.scss']
})
export class AgregarEditarComponent implements OnInit {
  agregarProveedor: FormGroup;
  accion = 'Agregar';
  id = 0;
  proveedor: Proveedor | undefined;

  constructor(private fb: FormBuilder,
    private _shop_service: ShopService,
    private router: Router,
    private aRoute: ActivatedRoute,
    private toastr: ToastrService) {
this.agregarProveedor = this.fb.group({
name: ['', Validators.required],
description: ['', Validators.required],
telefono: ['', Validators.required],
correo: ['', Validators.required],
rubrosId: ['', Validators.required]
})
this.id = +this.aRoute.snapshot.paramMap.get('id')!;
}

ngOnInit(): void {
  this.esEditar();
}

esEditar(){

  if(this.id !== 0) {
    this.accion = 'Editar';
    this._shop_service.getProveedor(this.id).subscribe(data => {
      this.proveedor = data;
      this.agregarProveedor.patchValue({
        name: data.name,
        description: data.description,
        telefono: data.telefono,
        correo: data.correo,
        rubro: data.rubro,
        rubrosId: data.rubrosId
      })
    }, error => {
      console.log(error);
    })
  }
}


agregarEditarProveedor() {

  if(this.proveedor == undefined) {

    // Agregamos un nuevo comentario
    const  proveedor : Proveedor = {
      name: this.agregarProveedor.get('name')?.value,
      description: this.agregarProveedor.get('description')?.value,
      telefono: this.agregarProveedor.get('telefono')?.value,
      correo: this.agregarProveedor.get('correo')?.value,
      rubrosId: this.agregarProveedor.get('rubrosId')?.value,
      id: 0,
      rubro: ''
    }
    this._shop_service.saveProveedor(proveedor).subscribe(data => {
      this.toastr.success('El Proveedor fue registrado con exito', 'Proveedor registrado');
      this.router.navigate(['/proveedor']);
    }, error => {
      this.toastr.error('Opss Ocurrio un error!','Error');
      console.log(error);
    })
  } else {

    // Editamos comentario
    const proveedor: Proveedor = {
      id: this.proveedor.id,
      name: this.agregarProveedor.get('name')?.value,
      description: this.agregarProveedor.get('description')?.value,
      telefono: this.agregarProveedor.get('telefono')?.value,
      correo: this.agregarProveedor.get('correo')?.value,
      rubrosId: this.agregarProveedor.get('rubrosId')?.value,
      rubro: ''
    }

    this._shop_service.saveProveedor(proveedor).subscribe(data => {
      this.toastr.success('El Proveedor fue actualizado con exito', 'Proveedor registrado');
      this.router.navigate(['/proveedor']);
    }, error => {
      this.toastr.error('Opss Ocurrio un error!','Error');
      console.log(error);
    })

  }


}



}
