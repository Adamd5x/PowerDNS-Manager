import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, map } from 'rxjs';

import { environment } from 'src/environments/environment';
import { StartUpConfig } from '@shared/models/startup-config';
import { ApiResponse } from '@shared/models/api-response';
import { EMPTY_STARTUP } from '@shared/models/empty-config';

import { EndpointType } from '@shared/types/endpoint-type';
import { Endpoint } from '@shared/models/endpoint';

const startupConfigStorageKey = 'startup';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private config: any;

  constructor(private http: HttpClient) { }

  loadConfiguration(): Promise<void> {
    const apiUrl = `${environment.apiUrl}/api/config`;
    
    return firstValueFrom(
        this.http
            .get<ApiResponse<StartUpConfig>>(apiUrl))
            .then((response) => {
              const result = response;
              const data = result?.data as StartUpConfig;
              this.config = data;
              this.storeConfig(data);
    });
  }

  getConfig() {
    return this.config;
  }

  getEndpoint(type: EndpointType): string {
    const endpoints = this.getEndpoints();
    const found = endpoints[type];

    console.log(`Endpoint url: ${environment.apiUrl}/${found?.url}`);
    
    return found?.url;
  }

  private storeConfig(data: StartUpConfig): void {
    sessionStorage.setItem(startupConfigStorageKey, JSON.stringify(data));
  }

  private restoreConfig(): StartUpConfig {
    const startupJson = sessionStorage.getItem(startupConfigStorageKey);

    if (startupJson) {
      return JSON.parse(startupJson) as StartUpConfig;
    }

    return EMPTY_STARTUP;
  }

  private getEndpoints(): Record<string, Endpoint> {
    const data: Endpoint[] = this.restoreConfig().endpoints as Endpoint[]; 

    const endpointRecord = data.reduce<Record<string, Endpoint>>((item, endpoint) => {
      item[endpoint.endpointType]=endpoint;
      return item;
    }, {} );

    console.log(endpointRecord);    
    return endpointRecord;
  }
}
