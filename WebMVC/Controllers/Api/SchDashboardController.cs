using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMVC.Models;

namespace WebMVC.Controllers.Api
{
    [RoutePrefix("api/SchDashboard")]
    public class SchDashboardController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetSchoolEnrolment(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_Summary_PerInstitutions_Per_Class_By_Gendermvc2(id)
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
        [Route("StaffSummary/{id}")]
        public IHttpActionResult GetStaffSummary(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_Summary_PerInstitutionsStaff_By_Gender(id)
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
                    return Content(HttpStatusCode.BadRequest, "No School Staff Data in NEMIS Platform!!");
                }
            }
        }

        [HttpGet]
        [Route("School/{id}")]
        public IHttpActionResult GetSchoolMissing(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_GetInstitutionMissingData(id)
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
                    return Content(HttpStatusCode.BadRequest, "No Schools With Missing Geolocation Data in NEMIS Platform!!");
                }
            }
        }
        [HttpGet]
        [Route("Capitation/{id}")]
        public IHttpActionResult GetCapitation(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_GetMyCapitation(id)
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
                    return Content(HttpStatusCode.BadRequest, "There is No Capitation Data in NEMIS Platform!!");
                }
            }
        }
    }
}
