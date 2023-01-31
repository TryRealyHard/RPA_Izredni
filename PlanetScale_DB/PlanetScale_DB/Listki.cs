using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlanetScale_DB
{
    internal class Listki
    {
        public long ID_listka { get; set; }
        public long ID_uporabnika { get; set; }
        public string Naslov { get; set; }
        public string Vsebina { get; set; }
        public DateTime Datum_kreiranja { get; set; }
        public Listki()
        {
            ID_listka = 0;
            ID_uporabnika = 0;
            Naslov = "Nov Listek";
            Vsebina = "";
            Datum_kreiranja = DateTime.Now;
        }
        public Listki(long iD_listka, long iD_uporabnika, string naslov, string vsebina, DateTime datum_kreiranja)
        {
            ID_listka = iD_listka;
            ID_uporabnika = iD_uporabnika;
            Naslov = naslov;
            Vsebina = vsebina;
            Datum_kreiranja = datum_kreiranja;
        }
    }
}
