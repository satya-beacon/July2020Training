import { Component } from '@angular/core';
import { Employee } from '../models/employee';

@Component({
    selector: 'bfs-employee-list',
    templateUrl: './employee-list.component.html',
    styleUrls: ['./employee-list.component.css']
})

export class EmployeeListComponent {
    employees : Employee [] = [];

    constructor() {
        this.employees.push({ id: 1, name: 'satya', address: 'RI', salary : 1000});
        this.employees.push({id: 2, name: 'jake', address: 'NJ', salary: 12000});
    }
}