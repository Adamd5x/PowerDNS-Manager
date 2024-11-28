import { APP_INITIALIZER,
         NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient } from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { startupInitializer } from './initializer/initializerFactory';
import { ConfigService } from './initializer/config.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(),
    {
      provide: APP_INITIALIZER,
      useFactory: startupInitializer,      
      deps: [ConfigService],
      multi: true
    },
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
