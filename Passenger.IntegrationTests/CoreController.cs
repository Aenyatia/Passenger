using Microsoft.AspNetCore.Mvc.Testing;
using Passenger.Web;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace Passenger.IntegrationTests
{
	public abstract class CoreController : IClassFixture<WebApplicationFactory<Startup>>
	{
		protected readonly WebApplicationFactory<Startup> Factory;
		protected readonly HttpClient Client;

		protected CoreController(WebApplicationFactory<Startup> factory)
		{
			Factory = factory;
			Client = Factory.CreateClient();
		}

		protected static StringContent GetPayload(object obj)
		{
			var json = JsonConvert.SerializeObject(obj);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}
	}
}
