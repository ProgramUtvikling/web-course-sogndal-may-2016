
function Person(firstname, lastname, birthyear) {
	this.firstname = firstname;
	this.lastname = lastname;
	this.birthyear = birthyear;

}

Person.prototype.getAge = function () {
	return 2016 - this.birthyear;
}


Person.prototype.toString = function () {
	return "navn: " + this.firstname + " " + this.lastname + ", alder: " + this.getAge();
}

