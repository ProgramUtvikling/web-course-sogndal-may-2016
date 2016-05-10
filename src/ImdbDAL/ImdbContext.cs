﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.OptionsModel;

namespace ImdbDAL
{
	public class ImdbContext : DbContext
	{
		public ImdbContext(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;

		}

		public ImdbContext(IOptions<ImdbOptions> optionsAccessor)
			: this(optionsAccessor.Value.ConnectionString)
		{
		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Vote> Votes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>()
				.HasMany(m => m.Producers)
				.WithMany(a => a.ProducedMovies)
				.Map(c => c.ToTable("MovieProducer"));

			modelBuilder.Entity<Movie>()
				.HasMany(m => m.Directors)
				.WithMany(a => a.DirectedMovies)
				.Map(c => c.ToTable("MovieDirector"));

			modelBuilder.Entity<Movie>()
				.HasMany(m => m.Actors)
				.WithMany(a => a.ActedMovies)
				.Map(c => c.ToTable("MovieActor"));
		}
	}
}
