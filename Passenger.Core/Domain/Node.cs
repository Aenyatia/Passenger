using System;

namespace Passenger.Core.Domain
{
	public sealed class Node
	{
		public string Address { get; private set; }
		public double Longitude { get; private set; }
		public double Latitude { get; private set; }

		private Node(string address, double longitude, double latitude)
		{
			SetAddress(address);
			SetLongitude(longitude);
			SetLatitude(latitude);
		}

		public static Node Create(string address, double longitude, double latitude)
			=> new Node(address, longitude, latitude);

		public void SetAddress(string address)
		{
			if (string.IsNullOrWhiteSpace(address))
				throw new ArgumentException("Address is required.", nameof(address));

			Address = address;
		}

		public void SetLongitude(double longitude)
		{
			if (longitude < -180 || longitude > 180)
				throw new ArgumentException("Invalid value. [-180, 180].", nameof(longitude));

			Longitude = longitude;
		}

		public void SetLatitude(double latitude)
		{
			if (latitude < -90 || latitude > 90)
				throw new ArgumentException("Invalid value. [-90, 90].", nameof(latitude));

			Latitude = latitude;
		}
	}
}
