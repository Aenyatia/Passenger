using Autofac;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.IoC.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			//builder.RegisterAssemblyTypes(ThisAssembly)
			//	.Where(t => t.IsAssignableTo<IService>())
			//	.AsImplementedInterfaces()
			//	.InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(ThisAssembly)
				.AssignableTo<IService>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}
