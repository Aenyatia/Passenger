using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Dto;
using Passenger.Infrastructure.Exceptions;
using Passenger.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class DriverService : IDriverService
	{
		private readonly IDriverRepository _driverRepository;
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IVehicleProvider _vehicleProvider;

		public DriverService(IDriverRepository driverRepository, IMapper mapper,
			IUserRepository userRepository, IVehicleProvider vehicleProvider)
		{
			_driverRepository = driverRepository;
			_mapper = mapper;
			_userRepository = userRepository;
			_vehicleProvider = vehicleProvider;
		}

		public async Task<DriverDetailsDto> Get(Guid userId)
		{
			var driver = await _driverRepository.Get(userId);

			return _mapper.Map<DriverDetailsDto>(driver);
		}

		public async Task<IEnumerable<DriverDto>> GetAll()
		{
			var drivers = await _driverRepository.GetAll();

			return _mapper.Map<IEnumerable<DriverDto>>(drivers);
		}

		public async Task Create(Guid userId)
		{
			var user = await _userRepository.GetOrFail(userId);
			var driver = await _driverRepository.Get(userId);
			if (driver != null)
				throw new ServiceException(ServiceCode.DriverAlreadyExists, $"Driver with Id '{userId}' already exists.");

			driver = new Driver(user);
			await _driverRepository.Add(driver);
		}

		public async Task SetVehicle(Guid userId, string brand, string model)
		{
			var driver = await _driverRepository.GetOrFail(userId);
			var vehicleDetails = await _vehicleProvider.Get(brand, model);
			var vehicle = Vehicle.Create(vehicleDetails.Brand, vehicleDetails.Model, vehicleDetails.Seats);
			driver.SetVehicle(vehicle);
		}

		public async Task Remove(Guid userId)
		{
			var driver = await _driverRepository.GetOrFail(userId);
			await _driverRepository.Delete(driver);
		}
	}
}
