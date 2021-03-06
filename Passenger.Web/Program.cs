﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;

namespace Passenger.Web
{
	public class Program
	{
		public static void Main(string[] args)
			=> CreateWebHostBuilder(args).Build().Run();

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
			=> WebHost.CreateDefaultBuilder(args)
				.UseNLog()
				.UseStartup<Startup>();
	}
}
