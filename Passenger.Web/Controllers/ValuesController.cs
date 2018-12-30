using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Settings;
using System.Collections.Generic;

namespace Passenger.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly GeneralSettings _generalSettings;

		public ValuesController(GeneralSettings generalSettings)
		{
			_generalSettings = generalSettings;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new[] { "value1", "value2", _generalSettings.AppName };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
