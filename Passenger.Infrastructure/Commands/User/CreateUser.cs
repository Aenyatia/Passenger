﻿using Passenger.Infrastructure.CQS.Commands;

namespace Passenger.Infrastructure.Commands.User
{
	public class CreateUser : ICommand
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string Username { get; set; }
		public string Role { get; set; }
	}
}
