import { NgModule } from '@angular/core';

import { CoreModule } from '@core/core.module';

import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';
import { HomeComponent } from './home/home.component';
import { DataCenterRoutingModule } from './data-center-routing.module';
import { DataCenterService } from './services/data-center.service';
import { ConfigService } from 'src/app/initializer/config.service';


import { CreateNewComponent } from './create-new/create-new.component';

@NgModule({
  declarations: [
    HomeComponent,
    CreateNewComponent
  ],
  imports: [
    CoreModule,
    DataCenterRoutingModule,
    SharedModule,
    MaterialsModule
  ],
  providers: [
    DataCenterService,
    ConfigService
  ]
})
export class DataCenterModule { }
