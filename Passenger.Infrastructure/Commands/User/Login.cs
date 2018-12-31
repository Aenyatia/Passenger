using System;
using Passenger.Infrastructure.CQS.Commands;

namespace Passenger.Infrastructure.Commands.User
{
	public class Login : ICommand
	{
		public Guid TokenId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
