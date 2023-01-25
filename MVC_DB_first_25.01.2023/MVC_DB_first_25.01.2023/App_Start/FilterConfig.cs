using System.Web;
using System.Web.Mvc;

namespace MVC_DB_first_25._01._2023
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
