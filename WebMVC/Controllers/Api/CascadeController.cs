using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMVC.Models;

namespace WebMVC.Controllers.Api
{
    [RoutePrefix("api/Cascade")]
    public class CascadeController : ApiController
    {
        [HttpGet]
        [Route("Regions")]
        public IHttpActionResult GetRegions()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.REGIONs
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
                    return Content(HttpStatusCode.BadRequest, "No Regions Defined in NEMIS Platform!!");
                }
            }
        }

        [HttpGet]
        [Route("Counties")]
        public IHttpActionResult GetCounties()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.COUNTies
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
                    return Content(HttpStatusCode.BadRequest, "No Counties Defined in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("SubCounties/{id}")]
        public IHttpActionResult GetSubCounties(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.SUB_COUNTY
                              where p.County_Code == id
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
                    return Content(HttpStatusCode.BadRequest, "No Sub-Counties for County Code =" + id + " Defined in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("Constituencies/{id}")]
        public IHttpActionResult GetConstituencies(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.CONSTITUENCies
                              where p.County_Code == id
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
                    return Content(HttpStatusCode.BadRequest, "No Constituencies for County Code =" + id + " Defined in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("Wards/{id}")]
        public IHttpActionResult GetWards(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.WARDS
                              where p.Constituency_Code == id
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
                    return Content(HttpStatusCode.BadRequest, "No Wards for Constituency Code =" + id + " Defined in NEMIS!!");
                }
            }
        }
        [HttpGet]
        [Route("Zones/{id}")]
        public IHttpActionResult GetZones(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.ZONEs
                              where p.Sub_County_Code == id
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
                    return Content(HttpStatusCode.BadRequest, "No Zones for Sub-County Code =" + id + " Defined in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("Levels")]
        public IHttpActionResult GetLevels()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_LEVEL
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
                    return Content(HttpStatusCode.BadRequest, "No School Levels in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("EduTypes")]
        public IHttpActionResult GetEduTypes()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_InstTypes()
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Types in NEMIS!!");
                }
            }
        }
        [HttpGet]
        [Route("Deparments/{id}")]
        public IHttpActionResult GetDeparments(string id)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.DEPARTMENTS
                              where p.vote == id
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
                    return Content(HttpStatusCode.BadRequest, "No Deparments for Organization Code =" + id + " Defined in NEMIS!!");
                }
            }
        }
        
        [HttpGet]
        [Route("InstGrades/{UIC}/{levelcode}")]
        public IHttpActionResult GetInstGrades(string UIC, string levelcode)
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_ClassGrades2(UIC, levelcode)
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
                    return Content(HttpStatusCode.BadRequest, "No Grades Level = " + levelcode + " Defined in NEMIS!!");
                }
            }
        }


        [HttpGet]
        [Route("LearnerCategory")]
        public IHttpActionResult GetLearnerCategory()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_GetLearnerCategory()
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
                    return Content(HttpStatusCode.BadRequest, "No Learner Categories in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("RegStatus")]
        public IHttpActionResult GetRegStatus()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_STATUS
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
                    return Content(HttpStatusCode.BadRequest, "No Registraiton Status Labels in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionCategory")]
        public IHttpActionResult GetInstitutionCategory()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_CATEGORY
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Registration Categories in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionCluster")]
        public IHttpActionResult GetInstitutionCluster()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var mentity = (from p in Db.INSTITUTION_CLUSTERS
                               select p).ToArray();

                if (mentity != null)
                {
                    try
                    {
                        // Respond to JSON requests
                        return Content(HttpStatusCode.OK, mentity, Configuration.Formatters.JsonFormatter);
                    }
                    catch
                    {
                        return Content(HttpStatusCode.BadRequest, mentity);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No Institution Cluster Types in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionGender")]
        public IHttpActionResult GetInstitutionGender()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_GENDER
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Gender Types in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionAccommodationType")]
        public IHttpActionResult GetInstitutionAccommodationType()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_ACCOMMODATION
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Gender Types in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionMobilityType")]
        public IHttpActionResult GetInstitutionMobilityType()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_MOBILITY
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Mobility Types in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionFormalityType")]
        public IHttpActionResult GetInstitutionFormalityType()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_FORMALITY
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Formality Types in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionResidenceType")]
        public IHttpActionResult GetInstitutionResidenceType()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_RESIDENCE
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Residence Types in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("InstitutionEduSysType")]
        public IHttpActionResult GetInstitutionEduSysType()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.INSTITUTION_EDUCATION_SYSTEM
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
                    return Content(HttpStatusCode.BadRequest, "No Institution Education Systems in NEMIS!!");
                }
            }
        }

        [HttpGet]
        [Route("RecordsPerPage")]
        public IHttpActionResult GetRecordsPerPage()
        {
            using (NEMISEntities Db = new NEMISEntities())
            {
                var entity = (from p in Db.proc_Get_PageRecords()
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
                    return Content(HttpStatusCode.BadRequest, "No Records Per Page Defined in NEMIS!!");
                }
            }
        }
    }
}
