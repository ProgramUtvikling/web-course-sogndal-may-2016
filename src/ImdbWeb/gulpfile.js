/// <binding AfterBuild='default' />
console.log("Hello!!!");

var gulp = require('gulp');
var concat = require("gulp-concat");
var cssnano = require("gulp-cssnano");
var rename = require("gulp-rename");

gulp.task("build-js", ["clean-js"], function() {
});

gulp.task("clean-js", function() {
	//...
});

gulp.task("build-css", ["clean-css"], function () {
	return gulp.src(["wwwroot/Styles/*.css"])
		.pipe(concat("styles.css"))
		.pipe(gulp.dest("wwwroot/dist"))
		.pipe(cssnano({ safe: true }))
		.pipe(rename("styles.min.css"))
		.pipe(gulp.dest("wwwroot/dist"));
});

gulp.task("clean-css", function() {
	//...
});


gulp.task('default', ["build-js", "build-css"]);