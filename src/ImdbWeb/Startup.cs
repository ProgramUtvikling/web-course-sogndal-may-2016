using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using ImdbBL;
using ImdbDAL;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.IISPlatformHandler;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Core;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.StaticFiles.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace WebApplication2
{
	public class Startup
	{
		private readonly IConfigurationRoot _configuration;

		public Startup(IHostingEnvironment env)
		{
			var configurationBuilder = new ConfigurationBuilder();
			configurationBuilder.AddJsonFile("config.json");
			_configuration = configurationBuilder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();
			services.Configure<ImdbOptions>(_configuration.GetSection("Imdb"));

			services.Configure<MvcOptions>(options =>
			{
				var jsonOutputFormatter = new JsonOutputFormatter();
				jsonOutputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				options.OutputFormatters.Insert(0, jsonOutputFormatter);

				var jsonInputFormatter = new JsonInputFormatter();
				jsonInputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				options.InputFormatters.Insert(0, jsonInputFormatter);
			});


			services.AddScoped<IMovieService, DbMovieService>();
			services.AddTransient<ImdbContext>();

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseIISPlatformHandler();
			app.UseBrowserLink();
			app.UseDeveloperExceptionPage();
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseMvc();
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}
