$(function () {
	"use strict";

	var vm = {
		movies: ko.observable(null),
		movie: ko.observable(null),
		showMovie: showMovie,
		showAllMovies: showAllMovies,
		back: back
	};

	ko.applyBindings(vm);
	$(".fouc-hide").removeClass("fouc-hide");

	function back() {
		vm.movie(null);
	}

	function showMovie(movie) {
		Q($.ajax({ url: "/api/movies/" + movie.movieId }))
			.then(function (data) {
				vm.movie(data);
				//...
			}
 		);
	}

	function showAllMovies() {
		Q($.ajax({ url: "/api/movies" }))
			.then(function (data) {
				vm.movies(data);
				//...
			}
 		);
	}
});

