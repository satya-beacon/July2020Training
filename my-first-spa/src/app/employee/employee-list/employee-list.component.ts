import { Component, OnInit , OnDestroy, ViewEncapsulation } from '@angular/core';
import { Employee } from '../models/employee';

@Component({
    selector: 'bfs-employee-list',
    templateUrl: './employee-list.component.html',
    styleUrls: ['./employee-list.component.css'],
    encapsulation: ViewEncapsulation.Emulated
})

export class EmployeeListComponent implements OnInit, OnDestroy {
    employees : Employee [] = [];
    tempEployees: Employee[] = [];
    selectedEmployee: Employee;

    siteUrl = "https://www.beaconfireinc.com";
    siteUrlText = "Click here for Beaconfire";

    constructor() {
       //Use this only DI
    }

    ngOnInit() {
        this.employees.push({ id: 1, name: 'Satya Palakurla', address: 'RI', salary : 1000});
        this.employees.push({id: 2, name: 'Jake Smith', address: 'NJ', salary: 12000});
        this.employees.push({id: 3, name: 'John ', address: 'NY', salary: 22});

        this.tempEployees = [...this.employees]; 
    }

    onSearch(event: any) : void {
        this.tempEployees = event;
    }

    onSetSelectedEmployee(employee: Employee) {
        this.selectedEmployee = employee;
    }
    
    ngOnDestroy() {
        this.employees = null;
        this.tempEployees = null;
    }
}