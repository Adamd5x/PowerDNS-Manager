import { Component, OnInit } from '@angular/core';
import { DataCenterService } from '../services/data-center.service';
import { EMPTY, Observable, tap } from 'rxjs';
import { DataCenter } from '../core/models/data-center';
import { LoadingService } from '@shared/components/loading/loading.service';

@Component({
  selector: 'app-home-datacenters',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  datacenters$: Observable<DataCenter[]> = EMPTY;

  columns = [
    'name',
    'city',
    'postalCode',
    'address',
    'region',
    'country',
    'action'
  ];

  constructor(private dataCenterService: DataCenterService,
              private loadinService: LoadingService) {

  }

  ngOnInit(): void {
    const loading$ = this.dataCenterService.getDataCentres();
    this.datacenters$ = this.loadinService
                            .showLoaderUntilCompleted<DataCenter[]>(loading$);
  }

  onEdit(item: DataCenter): void {

  }
}
