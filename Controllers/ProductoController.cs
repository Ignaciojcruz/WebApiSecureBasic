using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSecure.Models;

namespace WebApiSecure.Controllers
{
    [RoutePrefix("Api/Producto")]
    public class ProductoController : ApiController
    {
        [Authentication.BasicAuthentication]
        [HttpGet]
        [Route("ProductDetails")]
        public List<Producto> GetProducts()
        {
            List<Producto> lista = new List<Producto>();
            Producto p = new Producto(1,"beer");

            lista.Add(p);

            return lista;
        }
    }
}
