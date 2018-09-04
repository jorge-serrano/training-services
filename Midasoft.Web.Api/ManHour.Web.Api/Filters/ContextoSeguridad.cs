using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHour.Web.Api.Filters
{
    public class ContextoSeguridad
    {
        public string Company { get; set; }

        public DateTime Expiration { get; set; }

        public  String groups { get; set; }
    }
}