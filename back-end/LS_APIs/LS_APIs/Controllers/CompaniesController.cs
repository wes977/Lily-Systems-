///-------------------------------------------------------------------------------------------------
// file:	Controllers\CompaniesController.cs
//
// summary:	Implements the companies controller class
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
    /// <summary>   A controller for handling companies. </summary>
    ///

    ///-------------------------------------------------------------------------------------------------

    public class CompaniesController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = { "company_id", "companyName", "yearOfIncorporation", "active" };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the logic. </summary>
        ///

        ///
        /// <returns>   A mDAL. </returns>
        ///-------------------------------------------------------------------------------------------------

        private Logic mDAL = new Logic();
        // GET api/Companies

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a j array using the given identifier. </summary>
        ///

        ///
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("GetAll")]
        public JArray Get()
        {
            JArray tempList = new JArray();

            DataTable tempDT = mDAL.sCompany();

            foreach (DataRow row in tempDT.Rows)
            {
                Company_Info tempCI = new Company_Info(Int32.Parse(row[columnNames[0]].ToString()), row[columnNames[1]].ToString(), row[columnNames[2]].ToString(), Int32.Parse(row[columnNames[3]].ToString()));
                tempList.Add(JsonConvert.SerializeObject(tempCI));
            }

            return tempList;
        }

        // GET api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a j array using the given identifier. </summary>
        ///

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

            DataTable tempDT = mDAL.sCompany(id.ToString());

            foreach (DataRow row in tempDT.Rows)
            {
                Company_Info tempCI = new Company_Info(Int32.Parse(row[columnNames[0]].ToString()), row[columnNames[1]].ToString(), row[columnNames[2]].ToString(), Int32.Parse(row[columnNames[3]].ToString()));
                tempList.Add(JsonConvert.SerializeObject(tempCI));
            }

            return tempList;

        }


        // POST api/Companies

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Post this message. </summary>
        ///

        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An errorMSG. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public JArray Post([FromBody]Company_Info value)
        {
            errorHandling companyHandle = new errorHandling();
            JArray tempList = new JArray();
            List<errorMSG> returner = new List<errorMSG>();
            if ((returner = companyHandle.companyEH(value.companyName, value.yearOfInc)).Count == 0)  // if there is no errors and all that 
            {
                mDAL.Company(value.companyName, value.yearOfInc);
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

        ///
        /// <param name="id">       The Identifier to delete. </param>
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An errorMSG. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public JArray Put(int id, [FromBody]Company_Info value)
        {
            errorHandling companyHandle = new errorHandling();
            List<errorMSG> returner = new List<errorMSG>();
            JArray tempList = new JArray();
            if ((returner = companyHandle.companyEH(value.companyName, value.yearOfInc, id.ToString())).Count == 0)
            {
                mDAL.uCompany(id.ToString(), value.companyName, value.yearOfInc);
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

        ///
        /// <param name="id">   The Identifier to delete. </param>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
            mDAL.dCompany(id.ToString());
        }
    }
}