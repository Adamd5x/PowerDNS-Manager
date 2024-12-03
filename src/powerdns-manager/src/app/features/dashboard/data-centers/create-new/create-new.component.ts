import { Component } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { DataCenterService } from '../services/data-center.service';
import { LoadingService } from '@shared/components/loading/loading.service';
import { DataCenter } from '../core/models/data-center';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-new',
  templateUrl: './create-new.component.html',
  styleUrl: './create-new.component.scss'
})
export class CreateNewComponent {

  form = this.fb.group({
    name: ['', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(50)
    ]],
    address: ['', [
      Validators.maxLength(150)
    ]],
    city: ['',[
      Validators.maxLength(150)
    ]],
    postalCode: ['', [
      Validators.maxLength(50)
    ]],
    region: ['', [
      Validators.maxLength(50)
    ]],
    country: ['', [
      Validators.maxLength(50)
    ]],
    description:['',[
      Validators.maxLength(250)
    ]]
  });

  constructor(private fb: NonNullableFormBuilder,
              private dataCenterService: DataCenterService,
              private loadinService: LoadingService,
              private router: Router){}

  onSubmit(): void {
    if (this.form.valid) {
      this.loadinService.loadingOn();
      const formData = this.form.value;

      const save$ = this.dataCenterService
                        .createDataCenter({
        id: '',
        name: formData.name!,
        address: formData.address,
        city: formData.city,
        postalCode: formData.postalCode,
        region: formData.region,
        country: formData.country,
        description: formData.description
      });

      save$.subscribe({
            complete: () => {
              this.loadinService.loadingOff();
              this.router.navigate(['dashboard/datacenters']);
            }
          });
    }
  }
}
