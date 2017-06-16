///-------------------------------------------------------------------------------------------------
// file:	Controllers\RolesController.cs
//
// summary:	Implements the roles controller class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling roles. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class RolesController : Controller
    {
        // GET: Roles

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the index. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   A response stream to send to the Index View. </returns>
        ///-------------------------------------------------------------------------------------------------

        public ActionResult Index()
        {
            return View();
        }
    }
}