using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace IkinciElAracIhaleSistemi.UI
{
	public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error()
        {
			FormsAuthentication.SignOut();
		}
	}
}
