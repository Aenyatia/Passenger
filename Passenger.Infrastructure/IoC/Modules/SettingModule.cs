using Autofac;
using Microsoft.Extensions.Configuration;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Settings;

namespace Passenger.Infrastructure.IoC.Modules
{
	public class SettingModule : Module
	{
		private readonly IConfiguration _configuration;

		public SettingModule(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
				.SingleInstance();
		}
	}
}
