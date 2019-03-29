using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Rmdb.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "American Pie", "Scarface", "Home Alone" };
        }
    }
}
