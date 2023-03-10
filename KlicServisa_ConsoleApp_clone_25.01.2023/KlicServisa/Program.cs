using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KlicServisa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            HttpClient klient = new HttpClient();
            //pazi, da bo port pravi.
            klient.BaseAddress = new Uri("http://localhost:52753/");
            klient.DefaultRequestHeaders.Accept.Clear();
            klient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //pridobimo individualni item iz product's
            //HttpResponseMessage odgovor = await klient.GetAsync("api/Produkti/1");
            //if (odgovor.IsSuccessStatusCode)
            //{
            //    Product p = await odgovor.Content.ReadAsAsync<Product>();
            //    Console.WriteLine(p.Ime+" "+p.Cena);
            //}

            //pridobimo celotno listo produktov
            HttpResponseMessage odgovor = await klient.GetAsync("api/Produkti");
            if (odgovor.IsSuccessStatusCode)
            {
                List<Product> Vsi = await odgovor.Content.ReadAsAsync<List<Product>>();
                foreach(var p in Vsi)
                {
                    Console.WriteLine(p.Ime+" "+p.Cena);
                }
            }

            Console.ReadLine();
        }
    }
}
