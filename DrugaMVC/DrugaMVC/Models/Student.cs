using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrugaMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name ="Priimek in ime.")]
        [Required(ErrorMessage ="Ime je obvezno!")]
        public string Ime { get; set; }
        [Range(5,50)]
        public int Starost { get; set; }

    }
}