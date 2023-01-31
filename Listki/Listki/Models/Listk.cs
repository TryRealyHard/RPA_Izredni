using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listki.Models
{
    public class Listk
    {
        public int ID { get; set; }
        public virtual Uporabniki Uporabniki { get; set; }
        public int UporabnikiId { get; set; }
        public string Naslov { get; set; }
        public string Vsebina { get; set; }
        public DateTime Datum_kreiranja { get; set; }
    }
}