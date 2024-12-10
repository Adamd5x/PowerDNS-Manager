import { TestBed } from '@angular/core/testing';

import { ZonesServiceService } from './zones.service';

describe('ZonesServiceService', () => {
  let service: ZonesServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ZonesServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
