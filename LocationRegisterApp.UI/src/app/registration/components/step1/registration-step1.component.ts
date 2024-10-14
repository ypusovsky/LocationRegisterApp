import { Component, OnInit } from '@angular/core';
import { FormGroup, FormGroupDirective } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';

@Component({
  selector: 'app-registration-step1',
  templateUrl: './registration-step1.component.html',
  styleUrl: './registration-step1.component.css'
})
export class RegistrationStep1Component implements OnInit{
  formGroup!: FormGroup;
  constructor(
    public parent: FormGroupDirective, 
    private registrationService: RegistrationService) {}

  ngOnInit() {
    this.formGroup = this.parent.form.get('step1') as FormGroup;
  }

  public goToStep2() {
    if (this.formGroup.valid) {
      this.registrationService.currentStep = 2;
    }
  }
}
