﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImdbDAL
{
	public class Movie
	{
		[MaxLength(30)]
		public string MovieId { get; set; }

		[MaxLength(100)]
		public string Title { get; set; }

		[MaxLength(100)]
		public string OriginalTitle { get; set; }

		public string Description { get; set; }

		[MaxLength(4)]
		public string ProductionYear { get; set; }

		public int RunningLength { get; set; }

		[ForeignKey(nameof(Genre))]
		public int GenreId { get; set; }
		public virtual Genre Genre { get; set; }

		public virtual ICollection<Person> Actors { get; set; }
		public virtual ICollection<Person> Producers { get; set; }
		public virtual ICollection<Person> Directors { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Vote> Ratings { get; set; }
	}
}
