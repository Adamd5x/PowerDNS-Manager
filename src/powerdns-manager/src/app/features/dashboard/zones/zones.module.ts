import { ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ZonesRoutingModule } from './zones-routing.module';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';
import { ZonesService } from '@features/dashboard/zones/services/zones.service';
import { ManagerErrorHandler } from '@shared/handlers/manager-error-handler';
import { DataCenterService } from '../data-centers/services/data-center.service';
import { ServerService } from '../servers/services/server-service.service';
import { LoadingService } from '@shared/components/loading/loading.service';
import { LoadingModule } from '@shared/components/loading/loading.module';
import { NewZoneComponent } from './create-zone/new-zone/new-zone.component';


@NgModule({
  declarations: [
    HomeComponent,
    NewZoneComponent
  ],
  imports: [
    CommonModule,
    ZonesRoutingModule,
    SharedModule,
    MaterialsModule,
    LoadingModule
  ],
  providers: [
    ZonesService,
    DataCenterService,
    ServerService,
    LoadingService,
    {
      provide: ErrorHandler,
      useClass: ManagerErrorHandler
    }
  ]
})
export class ZonesModule { }
