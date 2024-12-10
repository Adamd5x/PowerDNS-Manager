import { ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ZonesRoutingModule } from './zones-routing.module';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';
import { ZonesService } from '@features/dashboard/zones/services/zones.service';
import { ManagerErrorHandler } from '@shared/handlers/manager-error-handler';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    ZonesRoutingModule,
    SharedModule,
    MaterialsModule
  ],
  providers: [
    ZonesService,
    {
      provide: ErrorHandler,
      useClass: ManagerErrorHandler
    }
  ]
})
export class ZonesModule { }
