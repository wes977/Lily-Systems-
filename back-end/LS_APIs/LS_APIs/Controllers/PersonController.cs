///-------------------------------------------------------------------------------------------------
// file:	controllers\personcontroller.cs
//
// summary:	Implements the personcontroller class
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
    /// <summary>   A controller for handling persons. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class PersonController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = {
            "person_id",
            "firstName",
            "lastName",
            "phoneNumber",
            "email",
            "personAddress",
            "postalCode",
            "country",
            "city",
            "socialNumber"};

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

            DataTable tempDT = mDAL.sPerson();

            foreach (DataRow row in tempDT.Rows)
            {
                Person_Info tempEI = new Person_Info(
                    Int32.Parse(row[columnNames[0]].ToString()),
                    row[columnNames[1]].ToString(),
                    row[columnNames[2]].ToString(),
                    row[columnNames[3]].ToString(),
                    row[columnNames[4]].ToString(),
                    row[columnNames[5]].ToString(),
                    row[columnNames[6]].ToString(),
                    row[columnNames[7]].ToString(),
                    row[columnNames[8]].ToString(),
                    row[columnNames[9]].ToString());
                tempList.Add(JsonConvert.SerializeObject(tempEI));
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

            DataTable tempDT = mDAL.sPerson(id.ToString());

            foreach (DataRow row in tempDT.Rows)
            {
                Person_Info tempEI = new Person_Info(
                    Int32.Parse(row[columnNames[0]].ToString()),
                    row[columnNames[1]].ToString(),
                    row[columnNames[2]].ToString(),
                    row[columnNames[3]].ToString(),
                    row[columnNames[4]].ToString(),
                    row[columnNames[5]].ToString(),
                    row[columnNames[6]].ToString(),
                    row[columnNames[7]].ToString(),
                    row[columnNames[8]].ToString(),
                    row[columnNames[9]].ToString());
                tempList.Add(JsonConvert.SerializeObject(tempEI));
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
        public JArray Post([FromBody]Person_Info value)
        {
            errorHandling companyHandle = new errorHandling();
            List<errorMSG> returner = new List<errorMSG>();
            JArray tempList = new JArray();
            if ((returner = companyHandle.personEH(value.fName,value.lName,value.phoneNum,value.email,value.personAddress,value.postalCode,value.country,value.city)).Count == 0)  // if there is no errors and all that 
            {
            mDAL.Person(
                            value.fName,
                            value.lName,
                            value.phoneNum,
                            value.email,
                            value.personAddress,
                            value.postalCode,
                            value.country,
                            value.city);
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
        public JArray Put(int id, [FromBody]Person_Info value)
        {
            errorHandling companyHandle = new errorHandling();
            List<errorMSG> returner = new List<errorMSG>();
            JArray tempList = new JArray();
            if ((returner = companyHandle.personEH(value.fName, value.lName, value.phoneNum, value.email, value.personAddress, value.postalCode, value.country, value.city, id.ToString())).Count == 0)  // if there is no errors and all that 
            {
                mDAL.uPerson(id.ToString(),
                                value.fName,
                                value.lName,
                                value.phoneNum,
                                value.email,
                                value.personAddress,
                                value.postalCode,
                                value.country,
                                value.city);
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

            // mDAL.dPerson(id);
        }
    }
}