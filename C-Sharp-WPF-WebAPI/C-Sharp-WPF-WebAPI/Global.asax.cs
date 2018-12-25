using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using C_Sharp_WPF_WebAPI.Models;

namespace C_Sharp_WPF_WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            OrganisationDB.FillDB();
            OrganisationDB.InitializeDB();
        }
    }
}
