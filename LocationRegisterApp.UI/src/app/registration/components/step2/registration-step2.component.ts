import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormGroup, FormGroupDirective } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';
import { CountryService } from '../../../services';
import { Country, Province } from '../../../models';
import { ProvinceService } from '../../../services/provinces.service';

@Component({
  selector: 'app-registration-step2',
  templateUrl: './registration-step2.component.html',
  styleUrl: './registration-step2.component.css'
})
export class RegistrationStep2Component implements OnInit{
  formGroup!: FormGroup;
  public selectedCountryId: number | null = null;
  public countiesLoading = false;
  public provinciesLoading = false;

  constructor(
    public parent: FormGroupDirective, 
    public registrationService: RegistrationService,
    private countryService: CountryService,
    private provinceService: ProvinceService) {}

  ngOnInit() {
    this.formGroup = this.parent.form.get('step2') as FormGroup;
    if (!this.registrationService.countries.length) {
      this.loadCountries();
    } 
  }

  public backToStep1() {
    this.registrationService.currentStep = 1;
  }

  public onCountryChange(countryId: number) {
    this.selectedCountryId = countryId;
    if (this.selectedCountryId) {
      this.provinciesLoading = true;
      this.formGroup.get('provinceId')?.setValue("");
      this.provinceService.getByCountryId(this.selectedCountryId).subscribe(provinces => {
          this.registrationService.provinces = provinces;
          this.provinciesLoading = false;
      });
    }
  }

  private loadCountries() {
    this.countiesLoading = true;
    this.countryService.getAll().subscribe(countries => {
        this.registrationService.countries = countries;
        this.countiesLoading = false;
      }
    );
  }
}
