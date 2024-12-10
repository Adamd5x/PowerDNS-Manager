import { Component, OnInit } from '@angular/core';
import { ZonesService } from '../services/zones.service';
import { EMPTY, Observable } from 'rxjs';
import { ZoneDetails } from '../core/models/zone-details';

@Component({
  selector: 'app-home-zones',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  zoneDetails$: Observable<ZoneDetails> = EMPTY;

  constructor(private zonesService: ZonesService){}

  ngOnInit(): void {
    this.zoneDetails$ = this.zonesService.getDetails('hihost.pl');
    
    this.zoneDetails$.subscribe();
  }
}
