import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DataService } from '@shared/base/data.service';
import { filter,
         map,
         Observable} from 'rxjs';
import { ConfigService } from 'src/app/initializer/config.service';
import { DataCenter } from '../core/models/data-center';
import { ApiResponse } from '@shared/models/api-response';

@Injectable()
export class DataCenterService extends DataService {

  private readonly apiUrl = this.configService
                                .getEndpoint('DataCenters');

  constructor(http: HttpClient,
              private configService: ConfigService) {
    super(http);
   }

   getDataCentres(): Observable<DataCenter[]> {
    return this.get<ApiResponse<DataCenter[]>>(this.apiUrl)
               .pipe(
                  filter(x => x.success),
                  map(m => m.data as DataCenter[]),
               );
   }

   getDataCenter(id: string): Observable<DataCenter> {
      return this.get<ApiResponse<DataCenter>>(`${this.apiUrl}/${id}`)
                 .pipe(
                  filter(x => x.success),
                  map(x => x.data as DataCenter)
                 );
   }

   createDataCenter(dataCenter: DataCenter): Observable<DataCenter> {
      return this.post<DataCenter>(`${this.apiUrl}`, dataCenter)
                 .pipe(
                  map(x => x as DataCenter)
                 );
   }

   updateDataCenter(id: string, dataCenter: Partial<DataCenter>): Observable<DataCenter> {
      return this.update<DataCenter>(`${this.apiUrl}/${id}`, dataCenter)
                 .pipe(
                     map(x => x as DataCenter)
                 );
   }
}
