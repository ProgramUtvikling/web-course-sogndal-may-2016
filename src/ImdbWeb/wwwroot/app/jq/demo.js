$(function () {
	"use strict";

	$("#findMovie").on("click", function () {
		var movieId = $("#movieId").val();
		$("#cph").load("/movie/details/" + movieId);
	});

	$("#showMovies").click(function () {
		var cph = $("#cph");
		cph.children().detach();

		Q($.ajax({ url: "/api/movies" }))
			.then(function (data) {

				var ul = $("<ul></ul>").appendTo(cph);
				data.forEach(function (movie) {
					$("<li data-movieid='" + movie.movieId + "'>" + movie.title + "</li>").appendTo(ul);
				});
			});
	});

	$("#cph").on("click", "ul > li", function (evt) {
		var movieId = $(this).data("movieid");
		$("#cph").load("/movie/details/" + movieId);
		evt.preventDefault();
	});
});

