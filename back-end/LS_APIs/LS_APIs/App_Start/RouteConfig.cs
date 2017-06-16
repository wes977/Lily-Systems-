///-------------------------------------------------------------------------------------------------
// file:	App_Start\RouteConfig.cs
//
// summary:	Implements the route configuration class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LS_APIs
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A route configuration. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class RouteConfig
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Registers the routes described by routes. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="routes">   The routes. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

