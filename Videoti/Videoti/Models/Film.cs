using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoti.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime Izdano { get; set; }
        public string Tip { get; set; }
        public decimal cena { get; set; }
    }
}