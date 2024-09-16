import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewProvinciasAdminComponent } from './view-provincias-admin.component';

describe('ViewProvinciasAdminComponent', () => {
  let component: ViewProvinciasAdminComponent;
  let fixture: ComponentFixture<ViewProvinciasAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewProvinciasAdminComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewProvinciasAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
