import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewStatusAdminComponent } from './view-status-admin.component';

describe('ViewStatusAdminComponent', () => {
  let component: ViewStatusAdminComponent;
  let fixture: ComponentFixture<ViewStatusAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewStatusAdminComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewStatusAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
