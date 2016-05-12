(function (undefined) {
	"use strict";

	$("#findMovie").click(function () {
		var movieId = $("#movieId").val();
		$("#cph").load("/movie/details/" + movieId);
	});

	//var movieId = $("#movieId").value;

	//Q($.ajax({ url: "/api/movies/fail" }))
	//   .then(function (data) {
	//   	console.log("4. Vi har fått data fra server");
	//   })
	//   .catch(function (err) {
	//   	console.log("Oooops!");
	//   });

})();