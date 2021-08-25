using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebApiDatesController : ControllerBase
    {
        [HttpGet("datetime")]
        public IActionResult GetDateTime([ModelBinder(BinderType = typeof(IsoDateModelBinder))] DateTime date)
        {
            return Ok();
        }
    }
}
