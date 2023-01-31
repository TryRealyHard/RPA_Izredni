using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetScale_DB
{
    static class Trenutna_prijava
    {
        public static string Uporabnisko_ime { get; set; }
        public static long UID_DB { get; set; }
        public static bool Je_prijavljen { get => je_prijavljen; set => je_prijavljen = value; }

        private static bool je_prijavljen = false;
    }
}
