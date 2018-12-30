using Autofac;
using Passenger.Infrastructure.Mappers;

namespace Passenger.Infrastructure.IoC.Modules
{
	public class AutoMapperModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(AutoMapperConfig.Initialize())
				.SingleInstance();
		}
	}
}
