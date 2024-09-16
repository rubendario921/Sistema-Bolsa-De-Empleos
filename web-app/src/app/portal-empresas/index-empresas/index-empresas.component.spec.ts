import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexEmpresasComponent } from './index-empresas.component';

describe('IndexEmpresasComponent', () => {
  let component: IndexEmpresasComponent;
  let fixture: ComponentFixture<IndexEmpresasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IndexEmpresasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IndexEmpresasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
