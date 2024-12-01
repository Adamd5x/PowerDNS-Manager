import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '@shared/shared.module';
import { MaterialsModule } from '@shared/materiald.module';
import { StateRoutingModuel } from './state-routing.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    StateRoutingModuel,
    SharedModule,
    MaterialsModule
  ]
})
export class StateModule { }
