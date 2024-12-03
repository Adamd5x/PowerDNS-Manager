import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServerService } from '../services/server-service.service';
import { Server } from '../core/models/server';
import { EMPTY, Observable } from 'rxjs';
import { HintItem } from '@shared/models/hint-item';

@Component({
  selector: 'app-create-new',
  templateUrl: './create-new.component.html',
  styleUrl: './create-new.component.scss'
})
export class CreateNewComponent implements OnInit {

  dataCenters$: Observable<HintItem[]> = EMPTY;

  form = this.fb.group({
    name: ['', [
      Validators.required
    ]],
    locationId: ['', [
      Validators.required
    ]],
    proto: ['', [
      Validators.required
    ]],
    hostAddress: ['', [
      Validators.required
    ]],
    port: ['', [
      Validators.required
    ]],
    apiKey: [''],
    auth: [''],
    version: [''],
    os: [''],
    configuration: [''],
    localId: ['', [
      Validators.required
    ]],
    timeout: ['30'],
    retries: ['3']
  });


  constructor(private fb: FormBuilder,
              private router: Router,
              private serverService: ServerService){}
  
  ngOnInit(): void {
    this.dataCenters$ = this.serverService.getDataCenters();  
  }

  onSubmit(): void {
    if (this.form.valid) {
      const serverData = this.form.value as Partial<Server>;
      const save$ = this.serverService
                        .createServer({
                          id: '',
                          name: serverData.name!,
                          locationId: serverData.locationId,
                          proto: serverData.proto!,
                          hostAddress: serverData.hostAddress!,
                          port: serverData.port!,
                          apiKey: serverData.apiKey,
                          auth: serverData.auth,
                          version: serverData.version,
                          os: serverData.os,
                          configuration: serverData.configuration,
                          localId: serverData.localId,
                          timeout: serverData.timeout,
                          retries: serverData.retries
                        });

      save$.subscribe({
        complete: () => {
          this.router.navigate(['dashboard/servers']);
        }
      })
    }
  }
}
