using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSecure.Models
{
    public class Producto
    {
        int id { get; set; }
        string name { get; set; }

        public Producto(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}