using Microsoft.AspNetCore.Builder;

namespace Passenger.Web.Framework
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseOwnExceptionHandler(this IApplicationBuilder app)
			=> app.UseMiddleware<ExceptionHandlerMiddleware>();
	}
}
