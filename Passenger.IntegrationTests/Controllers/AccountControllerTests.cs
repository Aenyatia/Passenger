using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Passenger.Infrastructure.Commands.User;
using Passenger.Web;
using Xunit;

namespace Passenger.IntegrationTests.Controllers
{
	public class AccountControllerTests : CoreController
	{
		public AccountControllerTests(WebApplicationFactory<Startup> factory)
			: base(factory)
		{
		}

		[Fact]
		public async void ChangeUserPassword_GivenValidCurrentAndNewPassword_PasswordShouldChanged()
		{
			var command = new ChangeUserPassword
			{
				CurrentPassword = "secreD1",
				NewPassword = "secreD2"
			};
			var payload = GetPayload(command);

			var respone = await Client.PutAsync("account/password", payload);

			respone.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
		}
	}
}
