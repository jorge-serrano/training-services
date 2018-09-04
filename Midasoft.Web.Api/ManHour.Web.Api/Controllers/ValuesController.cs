using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using ManHour.Web.Api.Filters;
using Microsoft.AspNet.Identity;

namespace ManHour.Web.Api.Controllers
{
    [JwtAuthentication]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
	        var principal = this.User.Identity as ClaimsIdentity;
	        var x = principal?.FindFirst(ClaimTypes.Name).Value;
	        var y = principal?.FindFirst(ClaimTypes.UserData).Value;
            return new string[] { x, y };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
