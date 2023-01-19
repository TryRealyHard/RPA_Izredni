using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Videoti.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        //https://localhost:xxxxx/helloworld - zagna Index by default
        public string Index()
        {
            return "Hello World!";
        }
        //https://localhost:xxxxx/helloworld/pozdravljen - pot do metode v url-ju brskalnika.
        //public string pozdravljen()
        //{
        //    return "To je druga metoda.";
        //}

        //https://localhost:xxxxx/helloworld/pozdravljen?ime=Erik&koliko=10 - klic z parametri.
        public ActionResult pozdravljen(string ime, int koliko=1)
        {
            ViewBag.Message = "Pozdravljen, " + ime; //preko VewBag-a lahko poserdujemo Viewerju sporočila.
            ViewBag.Num = koliko;
            return View();
        }
    }
}