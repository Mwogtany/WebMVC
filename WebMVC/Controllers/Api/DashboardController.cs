using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMVC.Models;

namespace WebMVC.Controllers.Api
{
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GeSummaryInstitutions(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_Summary_Institutions_Per_Level(id)
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
                    return Content(HttpStatusCode.BadRequest, "No Institutions Data in NEMIS Platform!!");
                }
            }
        }

        [HttpGet]
        [Route("EnrolSummaries/{id}")]
        public IHttpActionResult GeSummaryEnrolment(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_Summary_Staff_Per_Level(id)
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
                    return Content(HttpStatusCode.BadRequest, "No School Enrolment Data in NEMIS Platform!!");
                }
            }
        }
        [HttpGet]
        [Route("StaffSummaries/{id}")]
        public IHttpActionResult GStaffSummaries(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_Summary_Staff_Per_Level(id)
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
                    return Content(HttpStatusCode.BadRequest, "No Staff Data in NEMIS Platform!!");
                }
            }
        }
    }
}
