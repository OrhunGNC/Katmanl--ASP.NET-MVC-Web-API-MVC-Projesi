using System.Web;
using System.Web.Mvc;

namespace Katmanlı_ASP.NET_MVC_Web_API_MVC_Projesi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
