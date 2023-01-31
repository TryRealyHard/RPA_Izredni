using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listki.Models
{
    public class Uporabniki
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Uporabnisko { get; set; }
        public string Geslo { get; set; }
        public string Email { get; set; }
    }
}