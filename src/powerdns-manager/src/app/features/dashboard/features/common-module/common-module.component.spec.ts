import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonModuleComponent } from './common-module.component';

describe('CommonModuleComponent', () => {
  let component: CommonModuleComponent;
  let fixture: ComponentFixture<CommonModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommonModuleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommonModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
