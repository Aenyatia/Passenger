using Microsoft.IdentityModel.Tokens;
using Passenger.Infrastructure.Dto;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Passenger.Infrastructure.Services
{
	public class JwtHandler : IJwtHandler
	{
		private readonly JwtSettings _jwtSettings;

		public JwtHandler(JwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}

		public JwtDto CreateToken(Guid userId, string role)
		{
			var now = DateTime.UtcNow;
			var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
			var claims = new[]
			{
				new Claim(ClaimTypes.Role, role),
				new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Iat, now.GetEpoch().ToString(), ClaimValueTypes.Integer64)
			};
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
				SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				claims: claims,
				notBefore: now,
				expires: expires,
				signingCredentials: signingCredentials);

			var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

			return new JwtDto
			{
				Token = token,
				Expiry = expires.Ticks
			};
		}
	}
}
