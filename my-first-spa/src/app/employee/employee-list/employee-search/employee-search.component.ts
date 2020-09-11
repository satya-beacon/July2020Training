import { Component, Output, EventEmitter, Input } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../employee.service';

@Component({
    selector: 'employee-search',
    templateUrl: './employee-search.component.html',
    styleUrls: ['./employee-search.component.css']
})
export class EmployeeSearchComponent {
    filterQuery: string;
    @Output() emitSearch = new EventEmitter<Employee[]>();

    @Input() allEmployees: Employee[];

    constructor(private employeeService: EmployeeService){

    }

    search(event : any){
        let tempEployees = [];
        if(this.filterQuery !== null && this.filterQuery !== undefined && this.filterQuery != ''){
            tempEployees = this.employeeService.searchEmployeeByName(this.filterQuery);
        }else{
           tempEployees = this.allEmployees;
        }

        this.emitSearch.emit(tempEployees);
    }
}