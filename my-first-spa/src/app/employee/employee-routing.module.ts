import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-list/employee-detail/employee-detail.component';
import { AddEditEmployeeComponent } from './employee-list/add-edit-employee/add-edit-employee.component';

const routes : Routes = [
    {path: 'employees', component: EmployeeListComponent},
    {path: 'employees/:id', component: EmployeeDetailComponent},
    {path: 'add-edit-employee', component: AddEditEmployeeComponent}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class EmployeeRoutingModule 
{

}