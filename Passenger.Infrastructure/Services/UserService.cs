﻿using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Dto;
using Passenger.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IEncrypter _encrypter;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
		{
			_userRepository = userRepository;
			_encrypter = encrypter;
			_mapper = mapper;
		}

		public async Task<UserDto> Get(string email)
		{
			var user = await _userRepository.Get(email);

			return _mapper.Map<UserDto>(user);
		}

		public async Task<IEnumerable<UserDto>> GetAll()
		{
			var users = await _userRepository.GetAll();

			return _mapper.Map<IEnumerable<UserDto>>(users);
		}

		public async Task Login(string email, string password)
		{
			var user = await _userRepository.Get(email);
			if (user == null)
				throw new ServiceException(ServiceCode.InvalidCredentials, "Invalid email or password.");

			var hash = _encrypter.GetHash(password, user.Salt);
			if (user.PasswordHash != hash)
				throw new ServiceException(ServiceCode.InvalidCredentials, "Invalid email or password.");
		}

		public async Task Register(Guid id, string email, string username, string password, string role)
		{
			var user = await _userRepository.Get(email);
			if (user != null)
				throw new ServiceException(ServiceCode.EmailInUse, $"User with email '{email}' already exists.");

			var salt = _encrypter.GetSalt();
			var passwordHash = _encrypter.GetHash(password, salt);
			user = new User(id, email, passwordHash, salt, username, role);
			await _userRepository.Add(user);
		}
	}
}
