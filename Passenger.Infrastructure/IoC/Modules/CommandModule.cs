using Autofac;
using Passenger.Infrastructure.CQS.Commands;

namespace Passenger.Infrastructure.IoC.Modules
{
	public class CommandModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CommandDispatcher>()
				.As<ICommandDispatcher>()
				.InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(ThisAssembly)
				.AsClosedTypesOf(typeof(ICommandHandler<>))
				.InstancePerLifetimeScope();

			//builder.RegisterType<CreateUserHandler>()
			//	.As<ICommandHandler<CreateUserCommand>>()
			//	.InstancePerLifetimeScope();
		}
	}
}
