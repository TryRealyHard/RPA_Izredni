using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Vaja1_25._01._2023.Data
{
    public class MVC_Vaja1_25_01_2023Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVC_Vaja1_25_01_2023Context() : base("name=MVC_Vaja1_25_01_2023Context")
        {
        }

        public System.Data.Entity.DbSet<MVC_Vaja1_25._01._2023.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<MVC_Vaja1_25._01._2023.Models.Predmet> Predmets { get; set; }

        public System.Data.Entity.DbSet<MVC_Vaja1_25._01._2023.Models.Izpit> Izpits { get; set; }
    }
}
