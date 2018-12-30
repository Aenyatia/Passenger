using System;

namespace Passenger.Core.Domain
{
	public sealed class Vehicle
	{
		public string Brand { get; private set; }
		public string Model { get; private set; }
		public int Seats { get; private set; }

		private Vehicle(string brand, string model, int seats)
		{
			SetBrand(brand);
			SetModel(model);
			SetSeats(seats);
		}

		public Vehicle Create(string brand, string model, int seats)
		{
			return new Vehicle(brand, model, seats);
		}

		private void SetBrand(string brand)
		{
			if (string.IsNullOrWhiteSpace(brand))
				throw new ArgumentException("Brand is required.", nameof(brand));

			Brand = brand;
		}

		private void SetModel(string model)
		{
			if (string.IsNullOrWhiteSpace(model))
				throw new ArgumentException("Model is required.", nameof(model));

			Model = model;
		}

		private void SetSeats(int seats)
		{
			if (seats < 0)
				throw new ArgumentException("Invalid value.", nameof(seats));

			if (seats > 10)
				throw new ArgumentException("Invalid value.", nameof(seats));

			Seats = seats;
		}
	}
}
