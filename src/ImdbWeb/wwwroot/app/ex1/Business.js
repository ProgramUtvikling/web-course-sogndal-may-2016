
function Business(title, latitude, longitude){
    Place.apply(this, arguments);
}

Business.prototype = Object.create(Place.prototype);