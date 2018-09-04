using System.Net;
using System.Web.Http;

namespace ManHour.Web.Api.Controllers
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        public string Post(string username, string password, string companyId)
        {
            if (CheckUser(username, password, companyId))
            {
                return JwtManager.GenerateToken(username, companyId);
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
