import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeSearchComponent } from './employee-list/employee-search/employee-search.component';
import { EmployeeDetailComponent } from './employee-list/employee-detail/employee-detail.component';

//import routing module
import { EmployeeRoutingModule } from './employee-routing.module';
import { AddEditEmployeeComponent } from './employee-list/add-edit-employee/add-edit-employee.component';


@NgModule({
    declarations: [
        EmployeeListComponent,
        EmployeeSearchComponent,
        EmployeeDetailComponent,
        AddEditEmployeeComponent
        
    ],
    imports: [EmployeeRoutingModule, CommonModule, FormsModule ],
    exports: [],
})
export class EmployeeModule {

}