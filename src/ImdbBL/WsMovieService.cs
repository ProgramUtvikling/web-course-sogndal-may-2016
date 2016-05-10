using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ImdbDAL;

namespace ImdbBL
{
	public class WsMovieService : IMovieService
	{
		public Movie GetMovieById(string id)
		{
			var doc = XDocument.Load($"http://msu2014.azurewebsites.net/movie/details/{id}.xml");
			var movieElement = doc.Element("movie");
			if (movieElement == null)
			{
				return null;
			}

			var movie = new Movie
			{
				MovieId = (string)movieElement.Attribute("id"),
				Title = (string)movieElement.Attribute("title"),
				Description = movieElement.Element("description").Value
			};
			return movie;
		}

		public List<Movie> GetMovies()
		{
			var doc = XDocument.Load("http://msu2014.azurewebsites.net/imdbapi/movies");
			var movies = doc.Element("movies").Elements("movie").Select(movieElement => new Movie
			{
				MovieId = (string)movieElement.Attribute("id"),
				Title = movieElement.Value
			});
			return movies.ToList();
		}
	}
}