using System;

namespace Passenger.Core.Domain
{
	public sealed class User
	{
		public Guid Id { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
		public string Salt { get; private set; }
		public string Username { get; private set; }
		public string FullName { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		private User()
		{
		}

		public User(string email, string password, string salt, string username)
		{
			Id = Guid.NewGuid();
			Email = email.ToLowerInvariant();
			Password = password;
			Salt = salt;
			Username = username;

			CreatedAt = DateTime.UtcNow;
		}

		private void SetEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentException("Email is required.", nameof(email));


		}
	}
}
