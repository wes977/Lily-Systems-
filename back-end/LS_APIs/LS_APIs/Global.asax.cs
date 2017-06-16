///-------------------------------------------------------------------------------------------------
// file:	Global.asax.cs
//
// summary:	Implements the global.asax class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Threading;

namespace LS_APIs
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A web API application. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class WebApiApplication : System.Web.HttpApplication
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Application start. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        protected void Application_Start()
        {
            //Notifications note = new Notifications();
            //Thread noteThread = new Thread(new ThreadStart(note.NotificationMain));
            //noteThread.Start();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
