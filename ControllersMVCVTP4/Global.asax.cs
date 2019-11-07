using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersMVCVTP4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //This initializer sets a new database with the necessary datas populated on the database server
            //null value avoids the initial creation
            Database.SetInitializer<Models.EmployeeContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
