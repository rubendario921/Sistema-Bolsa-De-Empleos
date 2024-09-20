import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewOfertaEmpresasComponent } from './new-oferta-empresas.component';

describe('NewOfertaEmpresasComponent', () => {
  let component: NewOfertaEmpresasComponent;
  let fixture: ComponentFixture<NewOfertaEmpresasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewOfertaEmpresasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewOfertaEmpresasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
