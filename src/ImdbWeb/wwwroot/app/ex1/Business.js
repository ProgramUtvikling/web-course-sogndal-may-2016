
define(["ex1/Place"], function(Place) {
	"use strict";

	function Business(title, latitude, longitude) {
		Place.apply(this, arguments);
	}

	Business.prototype = Object.create(Place.prototype);

	return Business;
});