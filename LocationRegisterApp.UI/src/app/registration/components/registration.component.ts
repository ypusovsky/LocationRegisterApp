import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { matchPasswordValidator, passwordValidator } from '../../validators';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css',})
export class RegistrationComponent implements OnInit {  
  constructor(public registrationService: RegistrationService) {}

  ngOnInit() {
    this.createForm();
  }

  private createForm() {
    this.registrationService.registrationForm = new FormGroup({
      step1: new FormGroup({
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required, Validators.minLength(6), passwordValidator]),
        confirmPassword: new FormControl('', [Validators.required]),
        agreed: new FormControl(false, Validators.requiredTrue),        
      }, {validators: matchPasswordValidator}),
      step2: new FormGroup({
        countryId: new FormControl('', [Validators.required]),
        provinceId: new FormControl('', [Validators.required])
      })
    })
  }
}
