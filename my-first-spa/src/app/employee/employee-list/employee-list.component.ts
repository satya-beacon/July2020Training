import { Component, OnInit , OnDestroy, ViewEncapsulation } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../employee.service';

@Component({
    selector: 'bfs-employee-list',
    templateUrl: './employee-list.component.html',
    styleUrls: ['./employee-list.component.css'],
    encapsulation: ViewEncapsulation.Emulated,
})

export class EmployeeListComponent implements OnInit, OnDestroy {
    employees : Employee [] ;
    tempEployees: Employee[] = [];

    siteUrl = "https://www.beaconfireinc.com";
    siteUrlText = "Click here for Beaconfire";

    constructor(private employeeService: EmployeeService) {
       //Use this only DI
    }

    ngOnInit() {
        this.employees = this.employeeService.getEmployees();
        this.tempEployees = [...this.employees]; 
    }

    onSearch(event: any) : void {
        this.tempEployees = event;
    }

   
    ngOnDestroy() {
        this.employees = null;
        this.tempEployees = null;
    }
}