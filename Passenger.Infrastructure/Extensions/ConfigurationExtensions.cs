using Microsoft.Extensions.Configuration;

namespace Passenger.Infrastructure.Extensions
{
	public static class ConfigurationExtensions
	{
		public static T GetSettings<T>(this IConfiguration configuration) where T : new()
		{
			var section = typeof(T).Name.Replace("Settings", string.Empty);
			var instance = new T();

			configuration.GetSection(section).Bind(instance);
			return instance;
		}
	}
}
