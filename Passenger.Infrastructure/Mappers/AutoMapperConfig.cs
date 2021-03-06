﻿using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Dto;

namespace Passenger.Infrastructure.Mappers
{
	public static class AutoMapperConfig
	{
		public static IMapper Initialize()
			=> new MapperConfiguration(cfg =>
			 {
				 cfg.CreateMap<User, UserDto>();
				 cfg.CreateMap<Driver, DriverDto>();
				 cfg.CreateMap<Driver, DriverDetailsDto>();
				 cfg.CreateMap<Vehicle, VehicleDto>();
				 cfg.CreateMap<Route, RouteDto>();
				 cfg.CreateMap<DailyRoute, DriverDto>();
				 cfg.CreateMap<Node, NodeDto>();
			 }).CreateMapper();
	}
}
