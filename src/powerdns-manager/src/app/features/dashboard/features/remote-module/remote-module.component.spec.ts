import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoteModuleComponent } from './remote-module.component';

describe('RemoteModuleComponent', () => {
  let component: RemoteModuleComponent;
  let fixture: ComponentFixture<RemoteModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemoteModuleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemoteModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
