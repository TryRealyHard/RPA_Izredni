namespace MVC_Vaja1_25._01._2023.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Vaja1_25._01._2023.Data.MVC_Vaja1_25_01_2023Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVC_Vaja1_25._01._2023.Data.MVC_Vaja1_25_01_2023Context";
        }

        protected override void Seed(MVC_Vaja1_25._01._2023.Data.MVC_Vaja1_25_01_2023Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
