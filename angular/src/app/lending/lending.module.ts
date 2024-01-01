import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { LendingRoutingModule } from './lending-routing.module';
import { LendingComponent } from './lending.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [LendingComponent],
  imports: [SharedModule, LendingRoutingModule, NgbDatepickerModule],
})
export class LendingModule {}
