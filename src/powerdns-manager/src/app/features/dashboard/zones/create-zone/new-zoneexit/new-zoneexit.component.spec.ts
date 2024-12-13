import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewZoneexitComponent } from './new-zoneexit.component';

describe('NewZoneexitComponent', () => {
  let component: NewZoneexitComponent;
  let fixture: ComponentFixture<NewZoneexitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewZoneexitComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewZoneexitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
