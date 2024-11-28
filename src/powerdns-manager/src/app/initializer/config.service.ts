import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { StartUpConfig } from '@shared/models/startup-config';
import { ApiResponse } from '@shared/models/api-response';
import { EMPTY_STARTUP } from '@shared/models/empty-config';
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

  private getEndpoints(data: StartUpConfig): Endpoint[] {
    return data.endpoints as Endpoint[];
  }
}
