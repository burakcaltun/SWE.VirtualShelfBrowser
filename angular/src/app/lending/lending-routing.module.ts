import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LendingComponent } from './lending.component';

const routes: Routes = [{ path: '', component: LendingComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LendingRoutingModule { }
