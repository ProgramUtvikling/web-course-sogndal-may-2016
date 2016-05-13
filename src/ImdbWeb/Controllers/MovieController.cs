using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ImdbBL;
using ImdbDAL;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ViewFeatures;

namespace WebApplication2.Controllers
{
	[Route("Movie")]
	public class MovieController : Controller
	{
		private readonly IMovieService _movieService;

		public MovieController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[Route("Index")]
		public IActionResult Index()
		{
			ViewData.Model = _movieService.GetMovies();
			return View();
		}

		[Route(@"Details/{id}")]
		public IActionResult Details(string id)
		{
			var movie = _movieService.GetMovieById(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			ViewData.Model = movie;
			return View();
		}

		[Route("DetailsAsData1/{id}")]
		public IActionResult DetailsAsData1(string id)
		{
			var movie = _movieService.GetMovieById(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			var doc = new XElement("movie",
				new XAttribute("id", movie.MovieId),
				new XAttribute("title", movie.Title),
				new XAttribute("runLengt", movie.RunningLength),
				new XAttribute("prodYear", movie.ProductionYear)
			);

			return Content(doc.ToString(), "application/xml");
		}

		[HttpGet("~/api/movies/{id}")]
		public IActionResult GetMovie(string id)
		{
			var movie = _movieService.GetMovieById(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			return Ok(movie);
		}

		[HttpGet("~/api/movies")]
		public IActionResult GetMovies()
		{
			var movie = _movieService.GetMovies();

			return Ok(movie);
		}

		[HttpGet("~/api/movies/fail")]
		public IActionResult Fail()
		{
			throw new Exception();
		}

		[HttpPut("~/api/movies/{id}")]
		public IActionResult PostMovie(string id, Movie updatedMovie)
		{
			if (!ModelState.IsValid)
			{
				return HttpBadRequest(ModelState);
			}

			if (id != updatedMovie.MovieId)
			{
				return HttpBadRequest();
			}

			//if (!_movieService.MovieExists(id))
			//{
			//	return HttpNotFound();
			//}

			//if (!_movieService.UpdateMovie(id, updatedMovie))
			//{
			//	return HttpBadRequest();
			//}

			return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
		}

		[HttpDelete("~/api/movies/{id}")]
		public IActionResult DeleteMovie(string id)
		{
			//if (!_movieService.MovieExists(id))
			//{
			//	return HttpNotFound();
			//}

			//if (!_movieService.DeleteMovie(id))
			//{
			//	return HttpBadRequest();
			//}
			
			return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
		}

	}
}

