import { ChangeDetectionStrategy, Component,
         OnInit,
         inject } from '@angular/core';
import { DataCenterService } from '../services/data-center.service';
import { EMPTY,
         filter,
         Observable} from 'rxjs';
import { DataCenter } from '../core/models/data-center';
import { LoadingService } from '@shared/components/loading/loading.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DeleteDialogComponent } from '@shared/components/dialogs/delete/delete.component';

@Component({
  selector: 'app-home-datacenters',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit {
  readonly dialog = inject(MatDialog);

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
    this.loadData();
  }

  openDialog(enterAnimationDuration: string, exitAnimtionDuration: string, dataCenterId: string): void {
    const dialogData = {
      title: 'Delete data center',
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
          next: () => this.deleteDataCenter(dataCenterId)
        });
  }

  deleteDataCenter(dataCenterId: string): void {
    const delete$ = this.dataCenterService
                        .deleteDataCenter(dataCenterId);
    this.loadinService
        .showLoaderUntilCompleted(delete$)
        .subscribe({
          complete: () => this.loadData()
        });
  }

  private loadData(): void {
    const loading$ = this.dataCenterService.getDataCentres();
    this.datacenters$ = this.loadinService
                            .showLoaderUntilCompleted<DataCenter[]>(loading$);
  }
}
