using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Passenger.Core.Domain;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Passenger.Web.Framework
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _nextDelegate;

		public ExceptionHandlerMiddleware(RequestDelegate nextDelegate)
		{
			_nextDelegate = nextDelegate;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _nextDelegate.Invoke(context);
			}
			catch (Exception exception)
			{
				await HandleException(context, exception);
			}
		}

		private static async Task HandleException(HttpContext context, Exception exception)
		{
			var errorCode = "error";
			var statusCode = HttpStatusCode.BadRequest;
			var exceptionType = exception.GetType();

			switch (exception)
			{
				case Exception e when exceptionType == typeof(UnauthorizedAccessException):
					statusCode = HttpStatusCode.Unauthorized;
					break;

				case ServiceException e when exceptionType == typeof(ServiceException):
					statusCode = HttpStatusCode.BadRequest;
					errorCode = e.Code;
					break;

				default:
					statusCode = HttpStatusCode.InternalServerError;
					break;
			}

			var response = new { code = errorCode, message = exception.Message };
			var payload = JsonConvert.SerializeObject(response);

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)statusCode;

			await context.Response.WriteAsync(payload);
		}
	}
}
