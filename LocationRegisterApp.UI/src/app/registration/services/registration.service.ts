import { Injectable } from '@angular/core';
import { Country, Province, User } from '../../models';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../../services';
import { FormGroup } from '@angular/forms';

@Injectable()
export class RegistrationService {
    public registrationForm: FormGroup;
    public currentStep = 1;
    public countries : Country[] = [];
    public provinces : Province[] = [];

    constructor(
        private http: HttpClient,
        private userService: UserService) { }

    public registerUser(formData: 
        {
            step1: {email: string, password: string}, 
            step2: {countryId: number, provinceId: number}
        })  {
        return this.userService.create(
            {
                email: formData.step1.email,
                password: formData.step1.password,
                countryId: formData.step2.countryId,
                provinceId: formData.step2.provinceId
            } as User).subscribe(() => {
                alert('Saved successfully');
                this.currentStep = 1;
                this.registrationForm.reset();
            });
    }
}