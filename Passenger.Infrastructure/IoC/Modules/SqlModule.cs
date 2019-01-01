using Autofac;
using Passenger.Infrastructure.Repositories;

namespace Passenger.Infrastructure.IoC.Modules
{
	public class SqlModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(ThisAssembly)
				.AssignableTo<ISqlRepository>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}
