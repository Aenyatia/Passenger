using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
	public sealed class User
	{
		public Guid Id { get; private set; }
		public string Email { get; private set; }
		public string PasswordHash { get; private set; }
		public string Salt { get; private set; }
		public string Role { get; private set; }
		public string Username { get; private set; }
		public string FullName { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		public User(string email, string password, string salt, string username, string role)
		{
			Id = Guid.NewGuid();
			SetEmail(email);
			SetPassword(password);
			SetUsername(username);
			SetRole(role);
			Salt = salt;

			CreatedAt = DateTime.UtcNow;
		}

		public void SetUsername(string username)
		{
			if (string.IsNullOrWhiteSpace(username))
				throw new ArgumentException("Username is required.", nameof(username));

			if (Regex.IsMatch(username, @"[^\w]+$"))
				throw new ArgumentException("Invalid username.", nameof(username));

			if (Username == username)
				return;

			Username = username;
			UpdatedAt = DateTime.UtcNow;
		}

		public void SetEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentException("Email is required.", nameof(email));

			if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
				throw new ArgumentException("Invalid email.", nameof(email));

			if (Email == email)
				return;

			Email = email.ToLowerInvariant();
			UpdatedAt = DateTime.UtcNow;
		}

		public void SetPassword(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentException("PasswordHash is required.", nameof(password));

			//if (!Regex.IsMatch(password, @"^(?=.*[A-Z])"))
			//	throw new Exception("Required [A - Z].");

			//if (!Regex.IsMatch(password, @"^(?=.*[a-z])"))
			//	throw new Exception("Required [a - z].");

			//if (!Regex.IsMatch(password, @"^(?=.*\d)"))
			//	throw new Exception("Required [0 - 9].");

			//if (!Regex.IsMatch(password, @".{6,15}$"))
			//	throw new Exception("Required lenght 6 - 15.");

			if (PasswordHash == password)
				return;

			PasswordHash = password;
			UpdatedAt = DateTime.UtcNow;
		}

		public void SetRole(string role)
		{
			if (string.IsNullOrWhiteSpace(role))
				throw new ArgumentException("Role is required.", nameof(role));

			if (Role == role)
				return;

			Role = role;
			UpdatedAt = DateTime.UtcNow;
		}
	}
}
