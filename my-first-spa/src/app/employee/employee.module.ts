import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeSearchComponent } from './employee-list/employee-search/employee-search.component';
import { EmployeeDetailComponent } from './employee-list/employee-detail/employee-detail.component';

@NgModule({
    declarations: [
        EmployeeListComponent,
        EmployeeSearchComponent,
        EmployeeDetailComponent
        
    ],
    imports: [CommonModule, FormsModule],
    exports: [EmployeeListComponent],
    providers: []
})
export class EmployeeModule {

}