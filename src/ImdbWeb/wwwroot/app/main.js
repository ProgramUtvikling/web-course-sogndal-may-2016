
require(["ex1/Home", "ex1/Business"], function (Home, Business) {
	"use strict";

	var hjemme = new Home("Hjemme", 59.922315, 10.49115, "A+M+M+M+H");
	var hotellet = new Business("Hotellet", 61.229968, 7.098702);

	console.log(hjemme.toString());
	console.log(hotellet.toString());

});

