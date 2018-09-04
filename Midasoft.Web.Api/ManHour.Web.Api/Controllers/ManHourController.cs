using System.Collections.Generic;
using System.Web.Http;
using ManHour.Model;
using ManHour.Services;
using ManHour.Web.Api.Filters;
using ManHour.Web.Api.Models;

namespace ManHour.Web.Api.Controllers
{
    [JwtAuthentication]
    public class ManHourController : ApiController
    {
        // GET: api/ManHour
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ManHour/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ManHour
        public void Post([FromBody] ManHourModel model)
        {
            Actividad actividad = new Actividad();
            actividad.CodigoEmpleado = model.Empleado;
            actividad.Dispositivo = model.Dispositivo;
            actividad.FechaMarcacion = model.FechaMarcacion;
            ServicioPTUX.Agregar(actividad);
        }

        // PUT: api/ManHour/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ManHour/5
        public void Delete(int id)
        {
        }
    }
}
