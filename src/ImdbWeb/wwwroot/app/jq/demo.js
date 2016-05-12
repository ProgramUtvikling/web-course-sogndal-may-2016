(function (undefined) {
	"use strict";

	 Q($.ajax({ url: "/api/movies/fail" }))
		.then(function (data) {
			console.log("4. Vi har fått data fra server");
		})
		.catch(function() {
			 console.log("Oooops!");
		 });

})();