
function Place(title, latitude, longitude) {
	this.title = title;
	this.latitude = latitude;
	this.longitude = longitude;
}

Place.prototype.toString  = function () {
	return this.title + " (" + this.latitude + ", " + this.longitude + ")";
}
