using System.Web;
using System.Web.Mvc;

namespace CLC247_BenchMarkProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
