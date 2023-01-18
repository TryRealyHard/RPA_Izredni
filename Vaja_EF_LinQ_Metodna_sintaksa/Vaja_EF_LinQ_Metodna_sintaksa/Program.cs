using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaja_EF_LinQ_Metodna_sintaksa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DB na scng eucilnici "Elektrika" (.zip)

            ElektrikaEntities db = new ElektrikaEntities();

            //1. izberi čas meritve in skupno moč
            //ista poizvedba z lambda izrazom
            var x1 = db.Meritve.Select(a => new {a.ZapisČas, moc = a.kW1 + a.kW2 + a.kW3 }).Take(10);
            foreach(var x in x1)
            {
                Console.WriteLine(x.ZapisČas+" "+x.moc);
            }
            Console.WriteLine("----****\\|/****----");
            //2. izberi čas meritve in skupno moč za datum 18.8.2013
            DateTime d1 = DateTime.Parse("18.8.2013");
            DateTime d2 = DateTime.Parse("19.8.2013");
            var x2 = db.Meritve.Where(a => a.ZapisČas >= d1 && a.ZapisČas <= d2);

            foreach(var x in x2)
            {
                Console.WriteLine(x.ZapisČas);
            }
            Console.WriteLine("----****\\|/****----");
            //3. izračunaj povprečno moč za datum 18.8.2013
            //4. izračunaj maximalno moč za ta datum
            //5. izračunaj minimalno moč za ta datum
            //6. izračunaj povprečno moč po urah za dan 18.8.2013
            //7. izračunaj 15 minutna povprečja za 18.8.2013

            Console.ReadLine();
        }
    }
}
