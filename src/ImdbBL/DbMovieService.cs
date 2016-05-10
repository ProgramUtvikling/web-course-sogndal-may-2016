using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImdbDAL;

namespace ImdbBL
{
	public class DbMovieService : IMovieService
	{
		private readonly ImdbContext _db;

		public DbMovieService(ImdbContext db)
		{
			_db = db;
			//_db.Configuration.LazyLoadingEnabled = false;
			//_db.Configuration.ProxyCreationEnabled = false;
		}

		public List<Movie> GetMovies()
		{
			return _db.Movies.ToList();
		}

		public Movie GetMovieById(string id)
		{
			return _db.Movies.Find(id);
		}
	}
}
