import { NgModule } from '@angular/core';
import { RegistrationComponent } from './components/registration.component';
import { RegistrationStep1Component } from './components/step1/registration-step1.component';
import { FormGroupDirective, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { RegistrationService } from './services/registration.service';
import { RegistrationStep2Component } from './components/step2/registration-step2.component';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatButtonModule,
        MatSelectModule,
        MatOptionModule,
        MatProgressSpinner
    ],
    exports: [RegistrationComponent],
    declarations: [
        RegistrationComponent, 
        RegistrationStep1Component,
        RegistrationStep2Component
    ],
    providers: [FormGroupDirective, RegistrationService],
})
export class RegistrationModule { }
