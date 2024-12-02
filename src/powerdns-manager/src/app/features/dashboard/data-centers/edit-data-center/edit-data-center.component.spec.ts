import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDataCenterComponent } from './edit-data-center.component';

describe('EditDataCenterComponent', () => {
  let component: EditDataCenterComponent;
  let fixture: ComponentFixture<EditDataCenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditDataCenterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditDataCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
