﻿using System;
using System.Text.RegularExpressions;

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

		public User(string email, string password, string salt, string username)
		{
			Id = Guid.NewGuid();
			SetEmail(email);
			SetPassword(password);
			SetUsername(username);
			Salt = salt;

			CreatedAt = DateTime.UtcNow;
		}

		public void SetUsername(string username)
		{
			if (string.IsNullOrWhiteSpace(username))
				throw new ArgumentException("Username is required.", nameof(username));

			if (Regex.IsMatch(username, @"^[\w]"))
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

			if (Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
				throw new ArgumentException("Invalid email.", nameof(email));

			if (Email == email)
				return;

			Email = email.ToLowerInvariant();
			UpdatedAt = DateTime.UtcNow;
		}

		public void SetPassword(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentException("Password is required.", nameof(password));

			if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$"))
				throw new ArgumentException("Invalid password.", nameof(password));

			if (Password == password)
				return;

			Password = password;
			UpdatedAt = DateTime.UtcNow;
		}
	}
}
