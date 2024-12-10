import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { filter, map, Observable,
         of } from 'rxjs';

import { DataService } from '@shared/base/data.service';
import { ConfigService } from 'src/app/initializer/config.service';
import { ZoneDetails } from '../core/models/zone-details';
import { ApiResponse } from '@shared/models/api-response';
import { ZoneItem } from '../core/models/zone-item';

@Injectable()
export class ZonesService extends DataService {

  private readonly apiUrl = this.configService
                                .getEndpoint('Zones');

  constructor(httpClient: HttpClient,
              private configService: ConfigService) 
  {
    super(httpClient);
  }

  getList(serviceId: string): Observable<ZoneItem[]> {
    return this.get<ApiResponse<ZoneItem[]>>(`${this.apiUrl}`)
               .pipe(
                  filter(x => x.success),
                  map(x => x.data as ZoneItem[])
               );
  }

  getDetails(serviceId: string, zoneId: string): Observable<ZoneDetails> {
    return this.get<ApiResponse<ZoneDetails>>(`${this.apiUrl}/${serviceId}/zone/${zoneId}`)
               .pipe(
                  filter(x => x.success),
                  map(x => x.data as ZoneDetails)
               );
  }
}
