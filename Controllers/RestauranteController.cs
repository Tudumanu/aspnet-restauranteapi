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
    public class RestauranteController : ApiController
    {
        private WebAPIServicesContext db = new WebAPIServicesContext();

        // GET: api/Restaurante
        public IQueryable<Restaurante> GetRestaurantes()
        {
            return db.Restaurantes;
        }

        // GET: api/Restaurante/5
        [ResponseType(typeof(Restaurante))]
        public IHttpActionResult GetRestaurante(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return Ok(restaurante);
        }

        // PUT: api/Restaurante/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurante(int id, Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurante.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
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

        // POST: api/Restaurante
        [ResponseType(typeof(Restaurante))]
        public IHttpActionResult PostRestaurante(Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurantes.Add(restaurante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurante.Id }, restaurante);
        }

        // DELETE: api/Restaurante/5
        [ResponseType(typeof(Restaurante))]
        public IHttpActionResult DeleteRestaurante(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            db.Restaurantes.Remove(restaurante);
            db.SaveChanges();

            return Ok(restaurante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestauranteExists(int id)
        {
            return db.Restaurantes.Count(e => e.Id == id) > 0;
        }
    }
}