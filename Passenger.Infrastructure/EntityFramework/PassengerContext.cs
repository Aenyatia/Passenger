﻿using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Settings;

namespace Passenger.Infrastructure.EntityFramework
{
	public class PassengerContext : DbContext
	{
		private readonly SqlSettings _sqlSettings;

		public DbSet<User> Users { get; set; }

		public PassengerContext(DbContextOptions<PassengerContext> options, SqlSettings sqlSettings)
			: base(options)
		{
			_sqlSettings = sqlSettings;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var userBuilder = modelBuilder.Entity<User>();
			userBuilder.HasKey(x => x.Id);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (_sqlSettings.InMemory)
			{
				optionsBuilder.UseInMemoryDatabase("Passenger");
				return;
			}

			//optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString);
		}
	}
}
