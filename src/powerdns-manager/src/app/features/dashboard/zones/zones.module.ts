import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ZonesRoutingModule } from './zones-routing.module';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    ZonesRoutingModule,
    SharedModule,
    MaterialsModule
  ]
})
export class ZonesModule { }
