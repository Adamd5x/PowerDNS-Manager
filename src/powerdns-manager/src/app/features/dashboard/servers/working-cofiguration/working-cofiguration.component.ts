import { Component,
         OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Server } from '../core/models/server';
import { MatTableDataSource } from '@angular/material/table';
import { EMPTY } from 'rxjs';
import { ServiceConfigItem } from '../core/models/service-config-item';

@Component({
  selector: 'app-working-cofiguration',
  templateUrl: './working-cofiguration.component.html',
  styleUrl: './working-cofiguration.component.scss'
})
export class WorkingCofigurationComponent implements OnInit {

  constructor(private route: ActivatedRoute){}

  serviceDetails: Server | null = null;

  dataSource: MatTableDataSource<ServiceConfigItem> = new MatTableDataSource;

  columns = [
    'name',
    'value'
  ]

  ngOnInit(): void {
    
    const runningConfiguration = this.route
                                    .snapshot
                                    .data['serviceConfiguration'];

    this.dataSource = new MatTableDataSource(runningConfiguration);

    this.serviceDetails = this.route
                              .snapshot
                              .data['serviceDetails'] ;
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim()
                                        .toLowerCase();
  }
}
