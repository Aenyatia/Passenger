using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.Dto;
using Passenger.Web;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.IntegrationTests.Controllers
{
	public class UsersControllerTests : CoreController
	{
		public UsersControllerTests(WebApplicationFactory<Startup> factory)
			: base(factory)
		{
		}

		[Fact]
		public async void Get_GivenValidEmail_UserShouldExists()
		{
			var email = "user1@example.com";

			var user = await GetUserDto(email);

			user.Email.Should().BeEquivalentTo(email);
		}

		[Fact]
		public async void Get_GivenInvalidEmail_UserShouldNotExists()
		{
			var email = "notuser1@example.com";

			var response = await Client.GetAsync($"/users/{email}");

			response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
		}

		[Fact]
		public async void Get_GivenUniqueEmail_UserShouldBeCreated()
		{
			var command = new CreateUser
			{
				Email = "user10@example.com",
				Username = "user10",
				Password = "secreD1"
			};
			var payload = GetPayload(command);

			var response = await Client.PostAsync("/users", payload);

			response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
			response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{command.Email}");

			var user = await GetUserDto(command.Email);
			user.Email.Should().BeEquivalentTo(command.Email);
		}

		private async Task<UserDto> GetUserDto(string email)
		{
			var response = await Client.GetAsync($"users/{email}");
			var content = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<UserDto>(content);
		}
	}
}
