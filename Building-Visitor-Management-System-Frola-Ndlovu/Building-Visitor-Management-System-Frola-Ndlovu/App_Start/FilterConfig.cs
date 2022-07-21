using System.Web;
using System.Web.Mvc;

namespace Building_Visitor_Management_System_Frola_Ndlovu
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
