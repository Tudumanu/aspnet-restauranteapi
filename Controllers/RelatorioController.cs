using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIServices.Models;

namespace WebAPIServices.Controllers
{
    public class RelatorioController : ApiController
    {
        private WebAPIServicesContext db = new WebAPIServicesContext();

        [Route("api/PedidosGarcom/{id}")]
        public IHttpActionResult GetPedidosGarcom(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var pedidos = db.Pedidoes.Where(p => p.GarcomId == id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        [Route("api/PedidosMesa/{numeroMesa}")]
        public IHttpActionResult GetPedidosMesa(int numeroMesa)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var pedidos = db.Pedidoes.Where(p => p.NumeroMesa == numeroMesa);
            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
