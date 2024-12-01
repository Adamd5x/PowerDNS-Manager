import { Component, OnInit } from '@angular/core';
import { DataCenterService } from '../services/data-center.service';
import { EMPTY, Observable } from 'rxjs';
import { DataCenter } from '../core/models/data-center';

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

  constructor(private dataCenterService: DataCenterService) {}

  ngOnInit(): void {
    this.datacenters$ = this.dataCenterService.getDataCentres();
  }

}
