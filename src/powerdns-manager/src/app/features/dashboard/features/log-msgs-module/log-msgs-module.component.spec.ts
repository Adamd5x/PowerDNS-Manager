import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogMsgsModuleComponent } from './log-msgs-module.component';

describe('LogMsgsModuleComponent', () => {
  let component: LogMsgsModuleComponent;
  let fixture: ComponentFixture<LogMsgsModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LogMsgsModuleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LogMsgsModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
