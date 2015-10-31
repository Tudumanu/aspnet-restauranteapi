using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIServices.Models;

namespace WebAPIServices.Controllers
{
    public class GarcomController : ApiController
    {
        private WebAPIServicesContext db = new WebAPIServicesContext();

        // GET: api/Garcom
        public IQueryable<Garcom> GetGarcoms()
        {            
            db.Configuration.ProxyCreationEnabled = false;
            return db.Garcoms;
        }

        // GET: api/Garcom/5
        [ResponseType(typeof(Garcom))]
        public IHttpActionResult GetGarcom(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Garcom garcom = db.Garcoms.Find(id);
            if (garcom == null)
            {
                return NotFound();
            }

            return Ok(garcom);
        }

        // PUT: api/Garcom/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGarcom(int id, Garcom garcom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != garcom.Id)
            {
                return BadRequest();
            }

            db.Entry(garcom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarcomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Garcom
        [ResponseType(typeof(Garcom))]
        public IHttpActionResult PostGarcom(Garcom garcom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Garcoms.Add(garcom);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = garcom.Id }, garcom);
        }

        // DELETE: api/Garcom/5
        [ResponseType(typeof(Garcom))]
        public IHttpActionResult DeleteGarcom(int id)
        {
            Garcom garcom = db.Garcoms.Find(id);
            if (garcom == null)
            {
                return NotFound();
            }

            db.Garcoms.Remove(garcom);
            db.SaveChanges();

            return Ok(garcom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GarcomExists(int id)
        {
            return db.Garcoms.Count(e => e.Id == id) > 0;
        }
    }
}