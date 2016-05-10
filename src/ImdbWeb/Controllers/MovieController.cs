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

		[HttpGet("~/api/movie/{id}")]
		public IActionResult GetMovie(string id)
		{
			var movie = _movieService.GetMovieById(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			return Ok(movie);
		}

		[HttpGet("~/api/movie")]
		public IActionResult GetMovies()
		{
			var movie = _movieService.GetMovies();

			return Ok(movie);
		}

		[HttpPut("~/api/movie/{id}")]
		public IActionResult PostMovie(string id, Movie updatedMovie)
		{
			var existingMovie = _movieService.GetMovieById(id);
			if (existingMovie == null)
			{
				return HttpNotFound();
			}

			// oppdater filmen


			return new HttpStatusCodeResult(StatusCodes.Status201Created);
		}
	}
}
