import { Component,TemplateRef ,ElementRef, OnInit, ViewChild  } from '@angular/core';
import { Proveedor } from 'src/app/shared/models/proveedor';
import { ShopParams } from 'src/app/shared/models/shopParams';
import { ShopService } from '../shop/shop.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';




@Component({
  selector: 'app-proveedor',
  templateUrl: './proveedor.component.html',
  styleUrls: ['./proveedor.component.scss']
})
export class proveedorComponent implements OnInit {
 
  @ViewChild('search') searchTerm?: ElementRef;
  

  listProveedores: Proveedor[] = [];
  shopParams: ShopParams;

  modalRef!: BsModalRef;


  ngOnInit(): void {
    this.getProveedores();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
 }

  constructor(private shopService: ShopService,private modalService: BsModalService) {
    this.shopParams = shopService.getShopParams();
  }



  getProveedores() {
    this.shopService.getProveedores().subscribe({
      next: response => {
        this.listProveedores = response.data;
      },
      error: error => console.log(error)
    })
  }


  eliminarProveedor(id: any) {
    console.log(id);
  }

}
