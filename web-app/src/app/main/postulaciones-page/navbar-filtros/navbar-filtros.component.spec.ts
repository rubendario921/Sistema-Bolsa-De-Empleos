import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarFiltrosComponent } from './navbar-filtros.component';

describe('NavbarFiltrosComponent', () => {
  let component: NavbarFiltrosComponent;
  let fixture: ComponentFixture<NavbarFiltrosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavbarFiltrosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavbarFiltrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
