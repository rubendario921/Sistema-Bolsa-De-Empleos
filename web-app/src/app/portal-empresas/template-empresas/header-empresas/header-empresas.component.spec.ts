import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderEmpresasComponent } from './header-empresas.component';

describe('HeaderEmpresasComponent', () => {
  let component: HeaderEmpresasComponent;
  let fixture: ComponentFixture<HeaderEmpresasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HeaderEmpresasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HeaderEmpresasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
