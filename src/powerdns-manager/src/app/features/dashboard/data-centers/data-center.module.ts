import { NgModule } from '@angular/core';

import { CoreModule } from '@core/core.module';

import { LoadingService } from '@shared/components/loading/loading.service';
import { LoadingModule } from "@shared/components/loading/loading.module";
import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';
import { HomeComponent } from './home/home.component';
import { DataCenterRoutingModule } from './data-center-routing.module';
import { DataCenterService } from './services/data-center.service';
import { ConfigService } from 'src/app/initializer/config.service';


import { CreateNewComponent } from './create-new/create-new.component';
import { EditDataCenterComponent } from './edit-data-center/edit-data-center.component';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';

@NgModule({
  declarations: [
    HomeComponent,
    CreateNewComponent,
    EditDataCenterComponent
  ],
  imports: [
    CoreModule,
    DataCenterRoutingModule,
    SharedModule,
    MaterialsModule,
    LoadingModule
],
  providers: [
    DataCenterService,
    ConfigService,
    LoadingService,
    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: { hasBackdrop: false }
    }
  ]
})
export class DataCenterModule { }
