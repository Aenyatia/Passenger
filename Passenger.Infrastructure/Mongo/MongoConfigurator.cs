﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System.Collections.Generic;

namespace Passenger.Infrastructure.Mongo
{
	public static class MongoConfigurator
	{
		private static bool _initialized;

		public static void Initialize()
		{
			if (_initialized)
				return;

			RegisterConventions();
		}

		private static void RegisterConventions()
		{
			ConventionRegistry.Register("PassengerConventions", new MongoConvention(), x => true);
			_initialized = true;
		}

		private class MongoConvention : IConventionPack
		{
			public IEnumerable<IConvention> Conventions => new List<IConvention>
			{
				new IgnoreExtraElementsConvention(true),
				new CamelCaseElementNameConvention(),
				new EnumRepresentationConvention(BsonType.String)
			};
		}
	}
}