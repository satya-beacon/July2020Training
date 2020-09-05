var Sample = /** @class */ (function () {
    function Sample(msg) {
        this.isFullTime = false;
        this.message = msg;
    }
    Sample.prototype.setEmployeeToTime = function (val) {
        this.isFullTime = val;
    };
    return Sample;
}());
var obj = new Sample("Hello Typescript");
console.log(obj.message);
obj.setEmployeeToTime(true);
console.log(obj.isFullTime);
var EmployeeRepository = /** @class */ (function () {
    function EmployeeRepository(employeeId, employeeName, jobTitle, salary, address) {
        this.employeeId = employeeId;
        this.employeeName = employeeName;
        this.jobTitle = jobTitle;
        this.salary = salary;
        this.address = address;
    }
    EmployeeRepository.prototype.getInfo = function () {
        return "Id: " + this.employeeId + " Name: " + this.employeeName + "  JobTitle: " + this.jobTitle + " Salary: " + this.salary + " Addres: " + this.address;
    };
    return EmployeeRepository;
}());
var employeeReop = new EmployeeRepository(1, "satya", "manager", 2333, "RI");
console.log(employeeReop.getInfo());
