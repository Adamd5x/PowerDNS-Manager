import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { filter,
         map,
         Observable} from 'rxjs';

import { DataService } from "@shared/base/data.service";
import { ConfigService } from "src/app/initializer/config.service";
import { ApiResponse } from "@shared/models/api-response";
import { Server } from "../core/models/server";
import { HintItem } from "@shared/models/hint-item";
import { ServiceConfigItem } from "../core/models/service-config-item";

@Injectable()
export class ServerService extends DataService {
    private readonly apiUrl = this.configService
                                  .getEndpoint('Servers');

    constructor(http: HttpClient,
                private configService: ConfigService) {
        super(http);
    }

    getServers(dataCenterId: string): Observable<Server[]> {
        return this.get<ApiResponse<Server[]>>(`${this.apiUrl}/${dataCenterId}`)
                   .pipe(
                    filter((x: ApiResponse<Server[]>) => x.success),
                    map((x: ApiResponse<Server[]>) => x.data as Server[])
                   )
    }

    getServer(id: string): Observable<Server> {
        return this.get<ApiResponse<Server>>(`${this.apiUrl}/${id}/server`)
                   .pipe(
                    filter((x: ApiResponse<Server>) => x.success),
                    map((x: ApiResponse<Server>) => x.data as Server)
                   )
    }

    getDataCenters(): Observable<HintItem[]> {
        return this.get<ApiResponse<HintItem[]>>(`${this.apiUrl}/datacenters`)
                   .pipe(
                    filter((x: ApiResponse<HintItem[]>) => x.success),
                    map((x: ApiResponse<HintItem[]>) => x.data as HintItem[])
                   )
    }

    getServiceConfig(id: string): Observable<ServiceConfigItem[]> {
        return this.get<ApiResponse<ServiceConfigItem[]>>(`${this.apiUrl}/${id}/config`)
                   .pipe(
                    filter((x: ApiResponse<ServiceConfigItem[]>) => x.success),
                    map((x: ApiResponse<ServiceConfigItem[]>) => x.data as ServiceConfigItem[])
                   )
    }

    createServer(server: Server): Observable<Server> {
        return this.post<Server>(`${this.apiUrl}`, server)
                   .pipe(
                        map(x => x as Server)
                   );
    }

    updateServer(id: string, server: Partial<Server>): Observable<Server> {
        return this.update<Server>(`${this.apiUrl}/${id}`, server)
                   .pipe(
                       map(x => x as Server)
                   );
     }
  
     deleteServer(id: string): Observable<boolean> {
        return this.delete(`${this.apiUrl}/${id}`)
                   .pipe(
                       map((x: ApiResponse<boolean>) => x.success)
                   );
     }    
}