import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Proveedor } from 'src/app/shared/models/proveedor';
import { ShopService } from 'src/app/shop/shop.service';

@Component({
  selector: 'app-detalle-item',
  templateUrl: './detalle-item.component.html',
  styleUrls: ['./detalle-item.component.scss']
})
export class DetalleItemComponent implements OnInit {
  id: number;
  listProveedores: Proveedor | undefined;


constructor(private aRoute: ActivatedRoute,
  private _shop_service: ShopService) {
    this.id = +this.aRoute.snapshot.paramMap.get('id')!;
    }


  ngOnInit(): void {
    this.getProveedor();
  }


  getProveedor() {
    this._shop_service.getProveedor(this.id).subscribe(data => {
      this.listProveedores = data;
    }, error => {
      console.log(error);
    })
  }

  
}
