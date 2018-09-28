using ManHour.Web.Api.Models;
using System.Net;
using System.Web.Http;

namespace ManHour.Web.Api.Controllers
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        public string Post([FromBody] AuthenticationModel credentials)
        {
            if (CheckUser(credentials.Username, credentials.Password, credentials.CompanyId))
            {
                return JwtManager.GenerateToken(credentials.Username, credentials.CompanyId);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private bool CheckUser(string username, string password, string companyId)
        {
            // should check in the database
            return true;
        }
    }
}
