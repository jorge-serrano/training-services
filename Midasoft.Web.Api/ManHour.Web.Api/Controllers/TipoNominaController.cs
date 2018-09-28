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
        public IHttpActionResult  Get()
        {
            try
            {
                IEnumerable<TipoNomina> list = ServicioTNM.Find(null);
                return Ok(
                    list
                    );
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // GET: api/TipoNomina/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                IEnumerable<TipoNomina> list = ServicioTNM.Find(id);
                return Ok(
                    list.FirstOrDefault()??new TipoNomina()
                    );
            }
            catch (Exception)
            {

                return BadRequest();
            }
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
