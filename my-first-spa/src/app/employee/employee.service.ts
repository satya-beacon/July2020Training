import { Employee } from './models/employee';
import { EMPLOYEES } from './employee-list/mock/mock-employees';
import { Injectable } from '@angular/core';

//mark your servcice as injectable, i.e singleton

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    private data: Employee [] = EMPLOYEES;

    getEmployees() : Employee[] {
        return this.data;
    }


    getEmployeeById(id: number): Employee {
        let employee  = null;

        var result = this.data.filter(emp => emp.id === id);
        if(result != null && result.length > 0){
            employee = result[0];
        }

        return employee;
    }

    searchEmployeeByName(searchString: string): Employee[] {
        let tempEmployees = [];
        tempEmployees = this.data.filter(emp => emp.name.toLowerCase().indexOf(searchString.toLowerCase()) !== -1);
        return tempEmployees;
    }

}