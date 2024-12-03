import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServerService } from '../services/server-service.service';
import { Server } from '../core/models/server';


@Component({
  selector: 'app-edit-server',
  templateUrl: './edit-server.component.html',
  styleUrl: './edit-server.component.scss'
})
export class EditServerComponent implements OnInit {

  form = this.fb.group({
    id: [],
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
              private route: ActivatedRoute,
              private router: Router,
              private serverService: ServerService){}

  ngOnInit(): void {
    const server = this.route
                      .snapshot
                      .data['serverDetails'];

    this.form.setValue(server);
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
}