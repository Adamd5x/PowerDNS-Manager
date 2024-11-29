import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from '@angular/forms';

import { MaterialsModule } from "@shared/materiald.module";
import { SharedModule } from "@shared/shared.module";

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from "./login/login.component";
import { AuthService } from "src/app/services/auth.service";



@NgModule({
    imports: [
        ReactiveFormsModule,
        AuthRoutingModule,
        MaterialsModule,
        SharedModule
    ],
    declarations:[
        LoginComponent
    ],
    providers: [
        AuthService
    ]
})
export class AuthModule {}
