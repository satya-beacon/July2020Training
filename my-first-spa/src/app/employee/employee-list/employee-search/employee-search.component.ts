import { Component, Output, EventEmitter, Input } from '@angular/core';
import { Employee } from '../../models/employee';

@Component({
    selector: 'employee-search',
    templateUrl: './employee-search.component.html',
    styleUrls: ['./employee-search.component.css']
})
export class EmployeeSearchComponent {
    filterQuery: string;
    @Output() emitSearch = new EventEmitter<Employee[]>();

    @Input() allEmployees: Employee[];


    search(event : any){
        let tempEployees = [];
        if(this.filterQuery !== null && this.filterQuery !== undefined && this.filterQuery != ''){
            tempEployees = this.allEmployees.filter(emp => emp.name.toLowerCase().indexOf(this.filterQuery.toLowerCase()) !== -1);
        }else{
           tempEployees = this.allEmployees;
        }

        this.emitSearch.emit(tempEployees);
    }
}