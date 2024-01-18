import { ComponentFixture, TestBed } from '@angular/core/testing';

import { proveedorComponent } from './proveedor.component';

describe('ProveedorComponent', () => {
  let component: proveedorComponent;
  let fixture: ComponentFixture<proveedorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ proveedorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(proveedorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
