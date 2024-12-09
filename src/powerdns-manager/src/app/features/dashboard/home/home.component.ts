import { Component } from '@angular/core';
import { EMPTY, Observable, of } from 'rxjs';
import { StatisticsItem } from '../models/statistics-item';

@Component({
  selector: 'app-home-dashboard',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  service1: Observable<StatisticsItem> = of({name: 'ns001eu', value: '449300001'});
  service2: Observable<StatisticsItem> = of({name: 'ns002eu', value: '442394151'});
  service3: Observable<StatisticsItem> = of({name: 'master001eu', value: '449307091'});
  service4: Observable<StatisticsItem> = of({name: 'ns-dev', value: ''});
}
