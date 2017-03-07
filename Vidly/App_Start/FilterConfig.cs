using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // only authorized users can access site content (cat be owerriten in conroller with [Allow]
            filters.Add(new RequireHttpsAttribute()); // https only
        }
    }
}
