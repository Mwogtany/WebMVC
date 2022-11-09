using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMVC.Models;

namespace WebMVC.Controllers.Api
{
    [RoutePrefix("api/Institution")]
    public class InstitutionController : ApiController
    {
        [HttpGet]
        [Route("{SubCounty}/{LevelCode}/{TypeCode}")]
        public IHttpActionResult GeInstitutions(string SubCounty, string LevelCode, string TypeCode)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_Institutions(SubCounty, LevelCode, TypeCode)
                              select p).ToArray();
                if (entity != null)
                {
                    try
                    {
                        // Respond to JSON requests
                        return Content(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
                    }
                    catch
                    {
                        return Content(HttpStatusCode.BadRequest, entity);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No Institutions Data in NEMIS Platform for the Location/Level/Type Chosen!!");
                }
            }
        }

    }
}
