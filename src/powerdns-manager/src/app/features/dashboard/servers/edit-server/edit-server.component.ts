import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServerService } from '../services/server-service.service';
import { Server } from '../core/models/server';
import { ServiceConfigItem } from '../core/models/service-config-item';
import { filter } from 'rxjs';
import { ServiceMode } from '@shared/types/service-mode';


@Component({
  selector: 'app-edit-server',
  templateUrl: './edit-server.component.html',
  styleUrl: './edit-server.component.scss'
})
export class EditServerComponent implements OnInit {

  serviceMode: ServiceMode = 'Uknown';
  configurationList: ServiceConfigItem[] = [];

  private serverId = '';

  form = this.fb.group({
    id: [],
    name: ['', [
      Validators.required
    ]],
    description: [''],
    dataCenterId: ['', [
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
    serviceMode: ['']
  });


  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private router: Router,
              private serverService: ServerService){}

  ngOnInit(): void {
    const server = this.route
                      .snapshot
                      .data['serverDetails'];
    this.serverId = server.id;
    
    this.form.setValue(server);

    this.serviceMode = server.serviceMode;

    this.form
        .valueChanges
        .pipe(
          filter(x => x.serviceMode != 'Uknown')
        ) .subscribe(
          (result) => this.serviceMode = result.serviceMode as ServiceMode
        );
  }

  onSubmit(): void {
    if (this.form.valid) {
      const serverData = this.form.value as Partial<Server>;
      const save$ = this.serverService
                        .updateServer(serverData.id!, serverData);

      save$.subscribe({
        complete: () => {
          this.router.navigate(['dashboard/servers']);
        }
      })
    }
  }

  onRetrieveConfig(): void {
    this.serverService
        .getServiceConfig(this.serverId)
        .subscribe({
          next: (response: ServiceConfigItem[]) => {

             const primary = response.find(x => x.name === 'primary')?.value;
             const master = response.find(x => x.name === 'master')?.value;
             const secondary = response.find(x => x.name === 'secondary')?.value;
             const slave = response.find(x => x.name === 'slave')?.value;

             const isMaster = (primary === 'yes' || master === 'yes');
             const isSlave = (secondary == 'yes' || slave === 'yes');

            if (isMaster) {
              this.form.patchValue({
                serviceMode: 'Master'
              });
            } else if (isSlave) {
              this.form.patchValue({
                serviceMode: 'Slave'
              });
            } else {
              this.form.patchValue({
                serviceMode: 'Uknown'
              });
            }

             this.configurationList = response;

            const configDetails = JSON.stringify(response);
            this.form.patchValue({
              configuration: configDetails
            })
          }
        });
  }
}
