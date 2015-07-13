using System.Web;
using System.Web.Mvc;

namespace TestAppV_vici_V
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}