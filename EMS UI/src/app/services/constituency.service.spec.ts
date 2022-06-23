/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ConstituencyService } from './constituency.service';

describe('Service: Constituency', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConstituencyService]
    });
  });

  it('should ...', inject([ConstituencyService], (service: ConstituencyService) => {
    expect(service).toBeTruthy();
  }));
});
