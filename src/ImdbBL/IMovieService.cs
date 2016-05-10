using System.Collections.Generic;
using System.Threading.Tasks;
using ImdbDAL;

namespace ImdbBL
{
	public interface IMovieService
	{
		Movie GetMovieById(string id);
		List<Movie> GetMovies();
	}
}