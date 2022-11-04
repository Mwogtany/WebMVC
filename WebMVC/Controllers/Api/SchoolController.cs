using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMVC.Models;

namespace WebMVC.Controllers.Api
{
    [RoutePrefix("api/School")]
    public class SchoolController : ApiController
    {
        [HttpGet]
        [Route("Learners/{UIC}/{class_code}")]
        public IHttpActionResult GeLearners(string UIC, string class_Code)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_LearnersPerInstitution(UIC, class_Code)
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Learners Data in NEMIS Platform!!");
                }
            }
        }

        [HttpGet]
        [Route("TmpLearners/{UIC}/{class_code}")]
        public IHttpActionResult GeTmpLearners(string UIC, string class_Code)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_LearnerTmpPerInstitution(UIC, class_Code)
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Learners Without B/Cert Data in NEMIS Platform!!");
                }
            }
        }
    }
}
