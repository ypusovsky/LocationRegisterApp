import { AbstractControl } from '@angular/forms';

export function passwordValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const password = control.value;
    const hasUpperCase = /[A-Z]/.test(password);
    const hasNumeric = /[0-9]/.test(password);
    
    const isValid = hasUpperCase && hasNumeric;

    return password && !isValid ? { 'passwordStrength': true } : null;
}