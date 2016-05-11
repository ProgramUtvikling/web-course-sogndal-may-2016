
function Employee(firstname, lastname, birthyear, empNum, salary) {
	Person.apply(this, arguments);
	this.empNum = empNum;
	this.salary = salary;
}

Employee.prototype = Object.create(Person.prototype);

Employee.prototype.toString = function () {
	var s = Person.prototype.toString.call(this);
	return s + ", empNum: " + this.empNum + ", salary: " + this.salary;
};
