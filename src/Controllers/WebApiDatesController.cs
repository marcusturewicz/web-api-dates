using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiDates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebApiDatesController : ControllerBase
    {
        [HttpGet("datetime")]
        public IActionResult GetDateTime(
            [ModelBinder(BinderType = typeof(IsoDateModelBinder))] DateTime date)
        {
            return Ok();
        }

        // [HttpGet("string")]
        // public IActionResult GetString(string date)
        // {
        //     var startDateParsed = DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDateTime);

        //     if (!startDateParsed)
        //         return BadRequest("startDate must be in ISO-8601 format i.e. YYYY-MM-DD");

        //     return Ok();
        // }        
    }
}
