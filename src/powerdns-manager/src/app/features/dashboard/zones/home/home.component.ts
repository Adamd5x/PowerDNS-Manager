import { Component, OnInit } from '@angular/core';
import { ZonesService } from '../services/zones.service';
import { EMPTY, Observable } from 'rxjs';
import { ZoneDetails } from '../core/models/zone-details';
import { DataCenterService } from '@features/dashboard/data-centers/services/data-center.service';
import { DataCenter } from '@features/dashboard/data-centers/core/models/data-center';
import { ServerService } from '../../servers/services/server-service.service';
import { Server } from '@features/dashboard/servers/core/models/server';
import { ZoneItem } from '../core/models/zone-item';
import { LoadingService } from '@shared/components/loading/loading.service';

@Component({
  selector: 'app-home-zones',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  dataCenters$: Observable<DataCenter[]> = EMPTY;
  services$: Observable<Server[]> = EMPTY;
  zones$: Observable<ZoneItem[]> = EMPTY;
  zoneDetails$: Observable<ZoneDetails> = EMPTY;

  private dataCenterId = '';
  private serviceId = '';

  constructor(private dataCenterService: DataCenterService,
              private serviceService: ServerService,
              private zonesService: ZonesService,
              private loading: LoadingService){}

  ngOnInit(): void {
    this.dataCenters$ = this.dataCenterService
                            .getDataCentres();
  }

  onDataCenterClick(id: string): void {
    this.dataCenterId = id;    
    this.services$ = this.loading
                         .showLoaderUntilCompleted(this.serviceService
                                                       .getServers(this.dataCenterId));
  }

  onServiceClick(id: string): void {
    this.serviceId = id;    
    this.zones$ = this.loading
                      .showLoaderUntilCompleted(this.zonesService
                                                    .getList(this.serviceId));
  }

  onZoneDetailsClick(id: string): void {
    console.log(`Data center id: ${this.dataCenterId}; Service Id: ${this.serviceId}; Zone Id: ${id}`);
    
    this.zoneDetails$ = this.loading
                            .showLoaderUntilCompleted(this.zonesService
                            .getDetails(this.serviceId, id));
    this.zoneDetails$
        .subscribe();
  }
}
