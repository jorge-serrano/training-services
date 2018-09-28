using System.Linq;
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
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(ServicioPTUX.Obtener(null));
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (System.Exception )
            {

                return BadRequest("Something is not correct");

            }
        }

        // GET: api/ManHour/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var actividad = ServicioPTUX.Obtener(id).FirstOrDefault();
                if (actividad != null)
                    return Ok(actividad);
                return NotFound();
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (System.Exception )
            {

                return BadRequest("Something is not correct");

            }

        }

        // POST: api/ManHour
        public IHttpActionResult Post([FromBody] ManHourModel model)
        {
            try
            {
                Actividad actividad = new Actividad();
                actividad.CodigoEmpleado = model.Empleado;
                actividad.Dispositivo = model.Dispositivo;
                actividad.FechaMarcacion = model.FechaMarcacion;
                ServicioPTUX.Agregar(actividad);
                return Ok(new
                {
                    Code = 400,
                    Description = "Cretaed"
                });
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (System.Exception )
            {

                return BadRequest("Something is not correct");

            }
        }

        // PUT: api/ManHour/5
        public IHttpActionResult Put(int id, [FromBody]ManHourModel model)
        {
            try
            {
                Actividad actividad = ServicioPTUX.Obtener(id).FirstOrDefault();
                if (actividad == null)
                    return NotFound();
                actividad.Id = id;
                actividad.CodigoEmpleado = model.Empleado;
                actividad.Dispositivo = model.Dispositivo;
                actividad.FechaMarcacion = model.FechaMarcacion;
                ServicioPTUX.Actualizar(actividad);
                return Ok(actividad);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (System.Exception )
            {

                return BadRequest("Something is not correct");

            }

        }

        // DELETE: api/ManHour/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Actividad actividad = ServicioPTUX.Obtener(id).FirstOrDefault();
                if (actividad == null)
                    return NotFound();
                ServicioPTUX.Borrar(id);
                return Ok();
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (System.Exception )
            {

                return BadRequest("Something is not correct");

            }
        }
    }
}
