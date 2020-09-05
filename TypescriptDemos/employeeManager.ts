interface ILogger {
    logError(message: string) : void;
    logInfo(message: string) : void;
    logWarning(message: string) : void;
}


class LoggerService implements ILogger {
    logError(message: string) : void {
        console.log(`The error message : ${message}`);
    }

    logInfo(message: string) : void {
        console.log(`The Logged info ${message}`);
    }

    logWarning(message: string) : void {
        console.log(`The warning ${message}`);
    }
}


enum JobTitle {
    Developer,
    Intern,
    Manager
}

interface Employee {
    employeeId?: number;
    employeeName?: string;
    jobTitle?: JobTitle;
    salary?: number;
    address?: string;
}



class EmployeeManager {
    private employees: Employee[] = [];
    private readonly loggerService: ILogger;
    constructor(){
        this.loggerService = new LoggerService();

        this.employees.push({employeeId: 1, employeeName: 'satya', jobTitle: JobTitle.Developer, salary: 12000});
        this.employees.push({employeeId: 2, employeeName: 'Jobh', jobTitle: JobTitle.Manager, salary: 5000});
    }

    get getLength() : number {
        return this.employees.length;
    }

    public addNewEmployee(employee: Employee) : void {
        employee.employeeId = this.employees.length + 1;
        this.employees.push(employee);
        this.loggerService.logInfo(`Employee is added: ${employee.employeeId}`);
    }

    public removeEmployee(id: number) : void {
        for(let idx = 0; idx < this.employees.length; idx ++){
            if(this.employees[idx].employeeId === id){
                this.employees.splice(idx, 1);
                this.loggerService.logWarning(`Employee is removed: ${id}`);

                break;
            }
        }
    }

    public getEmployeeById(id: number) : Employee {
        let employee = null;
        for(let idx = 0; idx < this.employees.length; idx ++){
            if(this.employees[idx].employeeId === id){
               employee = this.employees[idx];
                break;
            }
        }
        return employee;
    }


    public getAllEmployees() : Employee[] {
        return this.employees;
    }

}

let repo = new EmployeeManager();
console.log(repo.getLength;

repo.addNewEmployee({employeeId: 3, employeeName: 'jake', jobTitle: JobTitle.Intern, salary: 444});

console.log(repo.getLength);

repo.removeEmployee(1);
console.log(repo.getLength);

window.onload = function() {

    let allEmpoyees = repo.getAllEmployees();
    let table = `<table><tr><th>Id</th><th>Name</th><th>JobTitle</th><th>Salary</th></tr>`;
    
    allEmpoyees.forEach(emp => {
      table += `<tr><td>${emp.employeeId}</td><td> ${emp.employeeName}</td><td> ${emp.jobTitle}</td><td> ${emp.salary}</td></tr>`;
    });
    table += `</table>`;
    
    document.getElementById("grid").innerHTML = table;    
}