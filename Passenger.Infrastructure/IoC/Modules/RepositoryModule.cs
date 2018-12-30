using Autofac;

namespace Passenger.Infrastructure.IoC.Modules
{
	public class RepositoryModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(ThisAssembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}
