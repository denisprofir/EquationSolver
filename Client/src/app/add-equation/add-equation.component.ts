import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-equation',
  templateUrl: './add-equation.component.html',
  styleUrls: ['./add-equation.component.css']
})
export class AddEquationComponent {
  addEquationForm = this.fb.group({
    coeffA: [null, Validators.compose([
      Validators.required, Validators.minLength(1)])
    ],
    coeffB: [null, Validators.compose([
      Validators.required, Validators.minLength(1)])
    ],
    coeffC: [null, Validators.compose([
      Validators.required, Validators.minLength(1)])
    ],
  });

  constructor(private fb: FormBuilder, private httpClient: HttpClient, private router: Router) {}

  onSubmit(): void {
    if (!this.addEquationForm.valid) {
      return;
    }

    const request = {
      coefficientA: this.addEquationForm.controls['coeffA'].value ?? 0,
      coefficientB: this.addEquationForm.controls['coeffB'].value ?? 0,
      coefficientC: this.addEquationForm.controls['coeffC'].value ?? 0,
    }

    this.httpClient.post('https://localhost:44349/equationsolver', request)
      .subscribe(data => {
        this.addEquationForm.reset();
        this.router.navigate(['/list-equation']);
      });
  }
}
