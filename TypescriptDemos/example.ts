class Sample {
    message: string;

    isFullTime: boolean = false;

    constructor(msg: string) {
        this.message = msg;
    }

    setEmployeeToTime(val : boolean) : void {
        this.isFullTime = val;
    }
}

let obj = new Sample("Hello Typescript");
console.log(obj.message);
obj.setEmployeeToTime(true);
console.log(obj.isFullTime);


class EmployeeRepository {
    employeeId: number;
    employeeName: string;
    jobTitle: string;
    salary : number;
    address: string;

    constructor(employeeId: number, employeeName: string, jobTitle: string, salary : number, address: string){
        this.employeeId = employeeId;
        this.employeeName = employeeName;
        this.jobTitle = jobTitle;
        this.salary = salary;
        this.address = address;
    }

    getInfo() : string{
         return `Id: ${this.employeeId} Name: ${this.employeeName}  JobTitle: ${this.jobTitle} Salary: ${this.salary} Addres: ${this.address}`
    }
}


let employeeReop =new EmployeeRepository(1, "satya", "manager", 2333, "RI");
console.log(employeeReop.getInfo());

