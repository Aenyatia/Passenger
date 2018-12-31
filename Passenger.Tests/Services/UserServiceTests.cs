﻿using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests.Services
{
	public class UserServiceTests
	{
		[Fact]
		public async void Register_GivenValidParams_ShouldAddNewUserToRepository()
		{
			var userRepositoryMock = new Mock<IUserRepository>();
			var mapperMock = new Mock<IMapper>();
			var encrypterMock = new Mock<IEncrypter>();
			var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, mapperMock.Object);

			await userService.Register("user1@example.com", "user1", "secreD1", "user");

			userRepositoryMock.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
		}
	}
}
