using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.Dto;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class DriverService : IDriverService
	{
		private readonly IDriverRepository _driverRepository;
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;

		public DriverService(IDriverRepository driverRepository, IMapper mapper, IUserRepository userRepository)
		{
			_driverRepository = driverRepository;
			_mapper = mapper;
			_userRepository = userRepository;
		}

		public async Task<DriverDto> Get(Guid userId)
		{
			var driver = await _driverRepository.Get(userId);

			return _mapper.Map<Driver, DriverDto>(driver);
		}

		public async Task Create(Guid userId, CreateDriver.DriverVehicle driverVehicle)
		{
			var user = await _userRepository.Get(userId);
			if (user == null)
				throw new InvalidOperationException($"User with Id '{userId}' does not exists.");

			var driver = await _driverRepository.Get(userId);
			if (driver != null)
				throw new InvalidOperationException($"User with Id '{userId}' is already exists.");

			var vehicle = Vehicle.Create(driverVehicle.Brand, driverVehicle.Model, driverVehicle.Seats);
			driver = new Driver(userId, vehicle);

			await _driverRepository.Add(driver);
		}
	}
}
