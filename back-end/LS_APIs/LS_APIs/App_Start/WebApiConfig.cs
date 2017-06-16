///-------------------------------------------------------------------------------------------------
// file:	App_Start\WebApiConfig.cs
//
// summary:	Implements the web API configuration class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LS_APIs
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A web API configuration. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public static class WebApiConfig
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Registers this object. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="config">   The configuration. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
