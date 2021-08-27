using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebApiDatesController : ControllerBase
    {
        [HttpGet("attribute")]
        public IActionResult GetAttribute([ModelBinder(BinderType = typeof(IsoDateModelBinder))] DateTime date)
        {
            return Ok();
        }

        [HttpGet("provider")]
        public IActionResult GetProvider(DateTime date)
        {
            return Ok();
        }        
    }
}
