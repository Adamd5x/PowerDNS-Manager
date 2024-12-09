import { Component,
         Input,
         TemplateRef } from '@angular/core';

import { StatisticsItem } from '../../models/statistics-item';
import { EMPTY,
         Observable } from 'rxjs';

const SecondsPerDay = 86400;

@Component({
  selector: 'common-module',
  templateUrl: './common-module.component.html',
  styleUrl: './common-module.component.scss'
})
export class CommonModuleComponent {
  @Input()
  placeholderTpl!: TemplateRef<any>;

  @Input()
  data: Observable<StatisticsItem> = EMPTY;

  @Input()
  serviceName = 'uknown service';

  calculateDays(seconds: string): string {
    if (isNaN(+seconds))
    {
      return '0';
    }

    return this.round(+seconds / SecondsPerDay, 2);
  }

  private round(value: number, precision: number): string {
    return Number(value).toFixed(precision);
  }
}
