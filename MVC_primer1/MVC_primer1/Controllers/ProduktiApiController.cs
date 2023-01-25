using MVC_primer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_primer1.Controllers
{
    public class ProduktiApiController : ApiController
    {
        Product[] produkti = new Product[]
        {
            new Product{ID=1, Ime="Paradižnik", Kategorija="Jestvina"},
            new Product{ID=2, Ime="sipghario", Kategorija="gjseghrh"}
        };
        public List<Product> GetProduct()
        {
            return produkti.ToList<Product>();
        }
        public Product GetProduct(int id)
        {
            var p = produkti.Where(a => a.ID == id).FirstOrDefault();
            return p;
        }
    }
}
