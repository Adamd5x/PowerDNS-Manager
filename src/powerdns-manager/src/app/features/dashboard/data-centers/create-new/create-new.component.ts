import { Component } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { DataCenterService } from '../services/data-center.service';

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
      Validators.maxLength(100)
    ]],
    postalCode: ['', [
      Validators.maxLength(20)
    ]],
    region: ['', [
      Validators.maxLength(50)
    ]],
    country: ['', [
      Validators.maxLength(100)
    ]]
  });

  constructor(private fb: NonNullableFormBuilder,
              private dataCenterService: DataCenterService){}

  onSubmit(): void {
    if (this.form.valid) {
      const formData = this.form.value;

      this.dataCenterService.createDataCenter({
        id: '',
        name: formData.name!,
        address: formData.address,
        city: formData.city,
        postalCode: formData.postalCode,
        region: formData.region,
        country: formData.country
      }).subscribe();
    }
  }
}
