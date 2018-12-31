using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.IoC;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Settings;
using System;
using System.Text;
using Passenger.Web.Framework;

namespace Passenger.Web
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
			=> Configuration = configuration;

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddMemoryCache();

			// authentication - jwt token
			var jwtSettings = Configuration.GetSettings<JwtSettings>();
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(x =>
				{
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),

						ValidateIssuer = false,
						ValidateAudience = false
					};
				});

			// authorization
			services.AddAuthorization(x =>
				x.AddPolicy("MustBeAdmin", p => p.RequireRole("admin")));

			// autofac
			var builder = new ContainerBuilder();
			builder.Populate(services);
			builder.RegisterModule(new ContainerModule(Configuration));
			return new AutofacServiceProvider(builder.Build());
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			// seed data
			var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
			if (generalSettings.SeedData)
			{
				var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
				dataInitializer.Seed();
			}

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();

			app.UseHttpsRedirection();
			app.UseOwnExceptionHandler();
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
