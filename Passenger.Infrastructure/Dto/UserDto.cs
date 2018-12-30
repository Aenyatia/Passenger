﻿using System;

namespace Passenger.Infrastructure.Dto
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string FullName { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}