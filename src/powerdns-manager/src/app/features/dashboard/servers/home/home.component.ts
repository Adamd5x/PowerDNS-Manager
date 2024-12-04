import { Component, inject, OnInit } from '@angular/core';
import { Observable,
         EMPTY, 
         filter} from 'rxjs';
import { MatDialog,
          MatDialogConfig } from '@angular/material/dialog';

import { Server } from '../core/models/server';
import { LoadingService } from '@shared/components/loading/loading.service';
import { ServerService } from '../services/server-service.service';
import { HintItem } from '@shared/models/hint-item';
import { DeleteDialogComponent } from '@shared/components/dialogs/delete/delete.component';
import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-home-servers',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  readonly dialog = inject(MatDialog);
  
  private dataCenterId = '';

  columns = [
    'name',
    'proto',
    'hostAddress',
    'port',
    'os',
    'localId',
    'action'
  ]

  dataCenters$: Observable<HintItem[]> = EMPTY;

  servers$: Observable<Server[]> = EMPTY;

    form = this.fb.group({
      dataCenterId: [null]
    });

  constructor(private fb: FormBuilder,
              private serverService: ServerService,
              private loadinService: LoadingService){}

  ngOnInit(): void {
    this.loadHints();
  }

  openDialog(enterAnimationDuration: string, exitAnimtionDuration: string, serverId: string): void {
    const dialogData = {
      title: 'Delete server',
      message: 'Are you sure?',
    }

    const dialogConfig: MatDialogConfig = {
      width: '250px',
      enterAnimationDuration: enterAnimationDuration,
      exitAnimationDuration: exitAnimtionDuration,
      data: dialogData
    };

    this.dialog
        .open(DeleteDialogComponent, dialogConfig)
        .afterClosed()
        .pipe(
          filter(x => x == true)
        )
        .subscribe({
          next: () => this.deleteServer(serverId)
        });
  }

  loadHints(): void {
    this.dataCenters$ = this.serverService.getDataCenters();
  }

  loadData(dataCenterId: string): void {
    const data$ = this.serverService.getServers(dataCenterId);
    this.servers$ = this.loadinService.showLoaderUntilCompleted<Server[]>(data$);
  }

  onChangeDataCenter(selected: any): void {
    if (selected) {
      this.dataCenterId = selected.value;
      this.loadData(selected.value);
    }
  }

  deleteServer(serverId: string): void {
    const delete$ = this.serverService
                        .deleteServer(serverId);
    this.loadinService
        .showLoaderUntilCompleted(delete$)
        .subscribe({
          complete: () => this.loadData(this.dataCenterId)
        });
  }  
}
