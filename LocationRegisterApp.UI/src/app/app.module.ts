import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { JsonPipe } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { provideHttpClient, withInterceptorsFromDi } from "@angular/common/http";
import { RegistrationModule } from "./registration/registration.module";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        JsonPipe,
        RegistrationModule
    ],
    declarations: [
        AppComponent
    ],
    providers: [
        provideHttpClient(withInterceptorsFromDi()),
    ],
    bootstrap: [AppComponent],
})
export class AppModule { }
