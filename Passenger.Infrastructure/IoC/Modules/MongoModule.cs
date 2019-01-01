using Autofac;
using MongoDB.Driver;
using Passenger.Infrastructure.Repositories;
using Passenger.Infrastructure.Settings;

namespace Passenger.Infrastructure.IoC.Modules
{
	public class MongoModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(context =>
			{
				var settings = context.Resolve<MongoSettings>();

				return new MongoClient(settings.ConnectionString);
			}).SingleInstance();

			builder.Register(context =>
			{
				var client = context.Resolve<MongoClient>();
				var settings = context.Resolve<MongoSettings>();
				var database = client.GetDatabase(settings.Database);

				return database;
			}).As<IMongoDatabase>();

			builder.RegisterAssemblyTypes(ThisAssembly)
				.AssignableTo<IMongoRepository>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}
