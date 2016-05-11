
function Home(title, latitude, longitude, whoLivesHere){
    Place.apply(this, arguments);
    this.whoLivesHere = whoLivesHere;
}

Home.prototype = Object.create(Place.prototype);

Home.prototype.toString = function () {
    var s = Place.prototype.toString.call(this);
    return s + ", Who lives here: " + this.whoLivesHere;
}