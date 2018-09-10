using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ManHour.Model;
using ManHour.Services;
using ManHour.Web.Api.Filters;
using ManHour.Web.Api.Models;

namespace ManHour.Web.Api.Controllers
{
   /// [JwtAuthentication]
    public class TipoNominaController : ApiController
    {
        // GET: api/TipoNomina
        public IEnumerable<TipoNomina> Get()
        {
            return null;
        }

        // GET: api/TipoNomina/5
        public TipoNomina Get(string id)
        {
            return null;
        }

        // POST: api/TipoNomina
        public IHttpActionResult Post([FromBody]TipoNominaDTO value)
        {
            try
            {
                ServicioTNM.Agregar(value.Tipo, value.Descripcion);
                return Ok(
                    new  { Description = "Todo bien" }
                    );
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT: api/TipoNomina/5
        public void Put(string id, [FromBody]TipoNominaDTO value)
        {
        }

        // DELETE: api/TipoNomina/5
        public void Delete(string id)
        {
        }
    }
}
