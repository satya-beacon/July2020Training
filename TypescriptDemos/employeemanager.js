var LoggerService = /** @class */ (function () {
    function LoggerService() {
    }
    LoggerService.prototype.logError = function (message) {
        console.log("The error message : " + message);
    };
    LoggerService.prototype.logInfo = function (message) {
        console.log("The Logged info " + message);
    };
    LoggerService.prototype.logWarning = function (message) {
        console.log("The warning " + message);
    };
    return LoggerService;
}());
var JobTitle;
(function (JobTitle) {
    JobTitle[JobTitle["Developer"] = 0] = "Developer";
    JobTitle[JobTitle["Intern"] = 1] = "Intern";
    JobTitle[JobTitle["Manager"] = 2] = "Manager";
})(JobTitle || (JobTitle = {}));
var EmployeeManager = /** @class */ (function () {
    function EmployeeManager() {
        this.employees = [];
        this.loggerService = new LoggerService();
        this.employees.push({ employeeId: 1, employeeName: 'satya', jobTitle: JobTitle.Developer, salary: 12000 });
        this.employees.push({ employeeId: 2, employeeName: 'Jobh', jobTitle: JobTitle.Manager, salary: 5000 });
    }
    EmployeeManager.prototype.getLength = function () {
        return this.employees.length;
    };
    EmployeeManager.prototype.addNewEmployee = function (employee) {
        employee.employeeId = this.employees.length + 1;
        this.employees.push(employee);
        this.loggerService.logInfo("Employee is added: " + employee.employeeId);
    };
    EmployeeManager.prototype.removeEmployee = function (id) {
        for (var idx = 0; idx < this.employees.length; idx++) {
            if (this.employees[idx].employeeId === id) {
                this.employees.splice(idx, 1);
                this.loggerService.logWarning("Employee is removed: " + id);
                break;
            }
        }
    };
    EmployeeManager.prototype.getEmployeeById = function (id) {
        var employee = null;
        for (var idx = 0; idx < this.employees.length; idx++) {
            if (this.employees[idx].employeeId === id) {
                employee = this.employees[idx];
                break;
            }
        }
        return employee;
    };
    EmployeeManager.prototype.getAllEmployees = function () {
        return this.employees;
    };
    return EmployeeManager;
}());
var repo = new EmployeeManager();
console.log(repo.getLength());
repo.addNewEmployee({ employeeId: 3, employeeName: 'jake', jobTitle: JobTitle.Intern, salary: 444 });
console.log(repo.getLength());
repo.removeEmployee(1);
console.log(repo.getLength());
window.onload = function () {
    var allEmpoyees = repo.getAllEmployees();
    var table = "<table><tr><th>Id</th><th>Name</th><th>JobTitle</th><th>Salary</th></tr>";
    allEmpoyees.forEach(function (emp) {
        table += "<tr><td>" + emp.employeeId + "</td><td> " + emp.employeeName + "</td><td> " + emp.jobTitle + "</td><td> " + emp.salary + "</td></tr>";
    });
    table += "</table>";
    document.getElementById("grid").innerHTML = table;
};
