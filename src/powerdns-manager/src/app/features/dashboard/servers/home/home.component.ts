import { Component, OnInit } from '@angular/core';
import { Observable,
         EMPTY } from 'rxjs';
import { Server } from '../core/models/server';
import { LoadingService } from '@shared/components/loading/loading.service';
import { ServerService } from '../services/server-service.service';
import { HintItem } from '@shared/models/hint-item';

@Component({
  selector: 'app-home-servers',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  columns = [
    'name',
    'proto',
    'hostAddress',
    'port',
    'os',
    'localId'
  ]

  dataCenters$: Observable<HintItem[]> = EMPTY;

  servers$: Observable<Server[]> = EMPTY;

  constructor(private serverService: ServerService,
              private loadinService: LoadingService){}

  ngOnInit(): void {
    this.loadHints();
  }

  openDialog(enterAnimationDuration: string, exitAnimtionDuration: string, serverId: string): void {

  }

  loadHints(): void {
    this.dataCenters$ = this.serverService.getDataCenters();
  }

  loadData(): void {
    
  }

  onChangeDataCenter(selected: any): void {
    if (selected) {
      const data$ = this.serverService.getServers(selected.value);
      this.servers$ = this.loadinService.showLoaderUntilCompleted<Server[]>(data$);
    }
  }
}
