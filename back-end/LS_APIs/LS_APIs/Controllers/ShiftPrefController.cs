///-------------------------------------------------------------------------------------------------
// file:	controllers\shiftprefcontroller.cs
//
// summary:	Implements the shiftprefcontroller class
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
    /// <summary>   A controller for handling shift preferences. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ShiftPrefController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = { "company_id", "companyName", "yearOfIncorporation", "active" };

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
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An errorMSG. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public errorMSG Post([FromBody]Company_Info value)
        {
            IValidation val = new IValidation();
            ErrorMessages eMSG = new ErrorMessages();
            errorMSG returnMsg = new errorMSG();
            returnMsg.errorMsg = "";
            returnMsg.errorCode = kErrorCodes.NoError;
            string errorMsg = "";
            int errorCode = kErrorCodes.NoError;
            try
            {

                if ((errorCode = val.checkForInput(value.companyName)) != kErrorCodes.NoError)
                {
                    errorMsg = eMSG.errorMessage(errorCode);
                    returnMsg.errorMsg = errorMsg;
                    returnMsg.errorCode = errorCode;
                }
                else if ((errorCode = val.checkForInput(value.yearOfInc)) != kErrorCodes.NoError)
                {
                    errorMsg = eMSG.errorMessage(errorCode);
                    returnMsg.errorMsg = errorMsg;
                    returnMsg.errorCode = errorCode;
                }
                else
                {
                    if ((errorCode = val.validateStoreName(value.companyName)) != kErrorCodes.NoError)
                    {
                        errorMsg = eMSG.errorMessage(errorCode);
                        returnMsg.errorMsg = errorMsg;
                        returnMsg.errorCode = errorCode;
                    }
                    else if ((errorCode = val.validateYearOfIncorperation(value.yearOfInc)) != kErrorCodes.NoError)
                    {
                        errorMsg = eMSG.errorMessage(errorCode);
                        returnMsg.errorMsg = errorMsg;
                        returnMsg.errorCode = errorCode;
                    }
                    else
                    {
                        mDAL.Company(value.companyName, value.yearOfInc);
                    }
                }
                return returnMsg;
            }
            catch (Exception e)
            {
                returnMsg.errorMsg = e.ToString();
                returnMsg.errorCode = 404;
                return returnMsg;
            }

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
        public errorMSG Put(int id, [FromBody]Company_Info value)
        {
            IValidation val = new IValidation();
            ErrorMessages eMSG = new ErrorMessages();
            errorMSG returnMsg = new errorMSG();
            returnMsg.errorMsg = "";
            returnMsg.errorCode = kErrorCodes.NoError;
            string errorMsg = "";
            int errorCode = kErrorCodes.NoError;
            try
            {
                if ((errorCode = val.checkForInput(id.ToString())) != kErrorCodes.NoError)
                {
                    errorMsg = eMSG.errorMessage(errorCode);
                    returnMsg.errorMsg = errorMsg;
                    returnMsg.errorCode = errorCode;
                }
                else if ((errorCode = val.checkForInput(value.companyName)) != kErrorCodes.NoError)
                {
                    errorMsg = eMSG.errorMessage(errorCode);
                    returnMsg.errorMsg = errorMsg;
                    returnMsg.errorCode = errorCode;
                }
                else if ((errorCode = val.checkForInput(value.yearOfInc)) != kErrorCodes.NoError)
                {
                    errorMsg = eMSG.errorMessage(errorCode);
                    returnMsg.errorMsg = errorMsg;
                    returnMsg.errorCode = errorCode;
                }
                else
                {
                    if ((errorCode = val.validateID(id.ToString())) != kErrorCodes.NoError)
                    {
                        errorMsg = eMSG.errorMessage(errorCode);
                        returnMsg.errorMsg = errorMsg;
                        returnMsg.errorCode = errorCode;
                    }
                    else if ((errorCode = val.validateStoreName(value.companyName)) != kErrorCodes.NoError)
                    {
                        errorMsg = eMSG.errorMessage(errorCode);
                        returnMsg.errorMsg = errorMsg;
                        returnMsg.errorCode = errorCode;
                    }
                    else if ((errorCode = val.validateYearOfIncorperation(value.yearOfInc)) != kErrorCodes.NoError)
                    {
                        errorMsg = eMSG.errorMessage(errorCode);
                        returnMsg.errorMsg = errorMsg;
                        returnMsg.errorCode = errorCode;
                    }
                    else
                    {
                        DataTable tempDT = mDAL.sCompany(id.ToString());
                        if (tempDT.Rows.Count != 1)
                        {
                            returnMsg.errorMsg = "No company Found with that ID";
                            returnMsg.errorCode = 405;
                        }
                        else
                        {
                            mDAL.uCompany(id.ToString(), value.companyName, value.yearOfInc);
                        }
                    }
                }
                return returnMsg;
            }
            catch (Exception e)
            {
                returnMsg.errorMsg = e.ToString();
                returnMsg.errorCode = 404;
                return returnMsg;
            }

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
            mDAL.dCompany(id.ToString());
        }
    }
}