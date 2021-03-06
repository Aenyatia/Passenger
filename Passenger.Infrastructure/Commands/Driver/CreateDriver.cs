﻿using Passenger.Infrastructure.Commands.Driver.Models;
using Passenger.Infrastructure.CQS.Commands;
using System;

namespace Passenger.Infrastructure.Commands.Driver
{
	public class CreateDriver : ICommand
	{
		public Guid UserId { get; set; }
		public DriverVehicle Vehicle { get; set; }
	}
}
