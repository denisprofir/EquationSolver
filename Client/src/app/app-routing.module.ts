import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddEquationComponent } from './add-equation/add-equation.component';
import { ListEquationComponent } from './list-equation/list-equation.component';

const routes: Routes = [
  {
    path: 'list-equation',
    component: ListEquationComponent
  },
  {
    path: 'add-equation',
    component: AddEquationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
