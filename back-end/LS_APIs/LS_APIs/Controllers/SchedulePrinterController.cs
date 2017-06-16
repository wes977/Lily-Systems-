///-------------------------------------------------------------------------------------------------
// file:	controllers\scheduleprintercontroller.cs
//
// summary:	Implements the scheduleprintercontroller class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using LS_APIs.DAL;
using System.Data;
using LS_APIs.Models;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LS_APIs.SchedulePrinter;
namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling schedule header printers. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ScheduleHeaderPrinterController : ApiController
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Schedule print. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   A SP. </returns>
        ///-------------------------------------------------------------------------------------------------

        SchedulePrint SP = new SchedulePrint();
        // GET api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a j array using the given identifier. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="id">   The Identifier to get. </param>
        ///
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public JArray Get(int id)
        {
            JArray tempList = new JArray();
            DataTable tempDT = SP.GetSchedule(id.ToString());
            tempList.Add(JsonConvert.SerializeObject(tempDT));
            return tempList;

        }

    }
}