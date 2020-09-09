import { Component, Input } from '@angular/core';

import { Employee } from '../../models/employee';

@Component({
  selector: 'bfs-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent  {

  @Input() employee: Employee;
 
}
