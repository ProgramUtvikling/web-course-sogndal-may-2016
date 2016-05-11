
function Shop(title, latitude, longitude, whatDoTheySell, openHours){
    Place.apply(this, arguments);
    this.whatDoTheySell = whatDoTheySell;
    this.openHours = openHours;
}

Shop.prototype = Object.create(Place.prototype);

Shop.prototype.toString = function () {
    var s = Place.prototype.toString.call(this);
    return s + ", What do they sell: " + this.whatDoTheySell + ", Opening hours: " + this.openHours;
}