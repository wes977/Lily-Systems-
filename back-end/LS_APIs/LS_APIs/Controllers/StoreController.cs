///-------------------------------------------------------------------------------------------------
// file:	controllers\storecontroller.cs
//
// summary:	Implements the storecontroller class
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

using LS_APIs.Validation;
namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling stores. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class StoreController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = {
            "store_id",
            "company_id",
            "divider",
            "storeAddress",
            "postalCode",
            "country",
            "city",
            "storePhone",
            "fax",
            "active"};

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

            DataTable tempDT = mDAL.sStore();

            foreach (DataRow row in tempDT.Rows)
            {
                Store_Info tempCI = new Store_Info(
                    Int32.Parse(row[columnNames[0]].ToString()),
                    Convert.ToInt32(row["company_id"].ToString()),
                    row["companyName"].ToString(),
                    Convert.ToInt32(row[columnNames[2]].ToString()),
                    row[columnNames[3]].ToString(),
                    row[columnNames[4]].ToString(),
                    row[columnNames[5]].ToString(),
                    row[columnNames[6]].ToString(),
                    row[columnNames[7]].ToString(),
                    row[columnNames[8]].ToString(),
                    Convert.ToInt32(row[columnNames[9]].ToString()));
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

            DataTable tempDT = mDAL.sStore(id.ToString());

            foreach (DataRow row in tempDT.Rows)
            {
                Store_Info tempCI = new Store_Info(
                    Int32.Parse(row[columnNames[0]].ToString()),
                    Int32.Parse(row["company_id"].ToString()),
                    row["companyName"].ToString(),
                    Convert.ToInt32(row[columnNames[2]].ToString()),
                    row[columnNames[3]].ToString(),
                    row[columnNames[4]].ToString(),
                    row[columnNames[5]].ToString(),
                    row[columnNames[6]].ToString(),
                    row[columnNames[7]].ToString(),
                    row[columnNames[8]].ToString(),
                    Convert.ToInt32(row[columnNames[9]].ToString()));
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
        ///
        /// <returns>   An errorMSG. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public JArray Post([FromBody]Store_Info value)
        {        
            errorHandling storeHandle = new errorHandling();
            List<errorMSG> returner = new List<errorMSG>();
            JArray tempList = new JArray();
            if ((returner = storeHandle.storeEH(value)).Count == 0)  // if there is no errors and all that 
            {
                mDAL.Store(
                    value.company_id.ToString(),
                    value.divider.ToString(),
                    value.storeAddress,
                    value.postalCode,
                    value.country,
                    value.city,
                    value.storePhone,
                    value.fax);
            }
            else
            {
                foreach (errorMSG em in returner)
                {
                    tempList.Add(JsonConvert.SerializeObject(em));
                }
            }
            return tempList;
        }

        // PUT api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Puts. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="id">       The Identifier to delete. </param>
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An errorMSG. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public JArray Put(int id, [FromBody]Store_Info value)
        {
            errorHandling storeHandle = new errorHandling();
            List<errorMSG> returner = new List<errorMSG>();
            JArray tempList = new JArray();
            if ((returner = storeHandle.storeEH(value, id.ToString())).Count == 0)  // if there is no errors and all that 
            {
                mDAL.uStore(
                id.ToString(),
                value.company_id.ToString(),
                value.divider.ToString(),
                value.storeAddress,
                value.postalCode,
                value.country,
                value.city,
                value.storePhone,
                value.fax);
            }
            else
            {
                foreach (errorMSG em in returner)
                {
                    tempList.Add(JsonConvert.SerializeObject(em));
                }
            }
            return tempList;
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
            mDAL.dStore(id.ToString());
        }
    }
}