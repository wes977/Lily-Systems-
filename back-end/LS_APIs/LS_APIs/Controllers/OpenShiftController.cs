///-------------------------------------------------------------------------------------------------
// file:	Controllers\OpenShiftController.cs
//
// summary:	Implements the open shift controller class
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

namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling open shifts. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class OpenShiftController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = {
            "openShit_id",
            "store_id",
            "shift_id"};

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the logic. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   A mDAL. </returns>
        ///-------------------------------------------------------------------------------------------------

        private Logic mDAL = new Logic();
        // GET api/Companies

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a j array using the given identifier. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("GetAll")]
        public JArray Get()
        {
            JArray tempList = new JArray();

            DataTable tempDT = mDAL.sOpenShift();

            foreach (DataRow row in tempDT.Rows)
            {
                Open_Shifts tempCI = new Open_Shifts();

                tempCI.openShift_id = Int32.Parse(row["openShift_id"].ToString());
                tempCI.shift_id = Int32.Parse(row["shift_id"].ToString());
                tempCI.store_id = Int32.Parse(row["store_id"].ToString());



                tempList.Add(JsonConvert.SerializeObject(tempCI));
            }

            return tempList;
        }

        // GET api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a j array using the given identifier. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="id">   The Identifier to delete. </param>
        ///
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public JArray Get(int id)
        {

            JArray tempList = new JArray();

            DataTable tempDT = mDAL.sOpenShift(id.ToString());

            foreach (DataRow row in tempDT.Rows)
            {
                Open_Shifts tempCI = new Open_Shifts();

                tempCI.openShift_id = Int32.Parse(row["openShift_id"].ToString());
                tempCI.shift_id = Int32.Parse(row["shift_id"].ToString());
                tempCI.store_id = Int32.Parse(row["store_id"].ToString());


                tempList.Add(JsonConvert.SerializeObject(tempCI));
            }

            return tempList;

        }


        // POST api/Companies

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Post this message. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]Shift_Info value)
        {
            mDAL.OpenShift(value.store_id.ToString(),value.shift_id.ToString());
        }

        // PUT api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Puts. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="id">       The Identifier to delete. </param>
        /// <param name="value">    The value. </param>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]Shift_Info value)
        {
            mDAL.tOpenShift(value.employee_id.ToString(), id.ToString());
            mDAL.dOpenShift(id.ToString());
        }

        // DELETE api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Deletes the given ID. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="id">   The Identifier to delete. </param>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
            mDAL.dOpenShift(id.ToString());
        }

    }
}
