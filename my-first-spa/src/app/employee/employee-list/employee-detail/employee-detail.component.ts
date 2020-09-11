import { Component, OnInit } from '@angular/core';

import { Employee } from '../../models/employee';
import { EmployeeService } from '../../employee.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'bfs-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit  {
 employee: Employee;
  constructor(private route : ActivatedRoute, private employeeService: EmployeeService){}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = parseInt(params.get('id'));
     
      this.employee = this.employeeService.getEmployeeById(id);
    });
  }
 
}
 