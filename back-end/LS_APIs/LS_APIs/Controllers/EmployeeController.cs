///-------------------------------------------------------------------------------------------------
// file:	controllers\employeecontroller.cs
//
// summary:	Implements the employeecontroller class
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
using LS_APIs.Security;
using LS_APIs.Validation;
using System.Web.Security;

namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling employees. </summary>
    ///

    ///-------------------------------------------------------------------------------------------------

    public class EmployeeController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = { "employee_id", "username", "password", "dateOfHire", "dateOfTermination", "store_id", "company_id", "person_id", "active" };
        /// <summary>   The second column names. </summary>
        public static readonly string[] columnNames2 = {
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

        public static readonly string[] roleNames =
{
            "Super Admin",
            "Admin",
            "Manager",
            "Supervisor",
            "User"

        };

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
            security sec = new security();
            DataTable tempDT = mDAL.sEmployee();

            foreach (DataRow row in tempDT.Rows)
            {
                Employee_Info tempEI = new Employee_Info(
                    Int32.Parse(row[columnNames[0]].ToString()),
                    row[columnNames[1]].ToString(),
                    row[columnNames[2]].ToString(),
                    Convert.ToDateTime(row[columnNames[3]].ToString()),
                    row[columnNames[4]].ToString(),
                    Int32.Parse(row[columnNames[5]].ToString()),
                    Int32.Parse(row[columnNames[6]].ToString()),
                    Int32.Parse(row[columnNames[7]].ToString()),
                    Int32.Parse(row[columnNames[8]].ToString()));
                foreach(string s in roleNames)
                {
                    if (sec.CheckUserInRole(tempEI.uName, s))
                    {
                        tempEI.role = s;
                    }
                }
                
                tempList.Add(JsonConvert.SerializeObject(tempEI));
            }

            return tempList;
        }

        // GET api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a j array using the given identifier. </summary>
        ///

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
            security sec = new security();
            JArray tempList = new JArray();

            DataTable tempDT = mDAL.sEmployee(id.ToString());

            foreach (DataRow row in tempDT.Rows)
            {
                Employee_Info tempEI = new Employee_Info(
                    Int32.Parse(row[columnNames[0]].ToString()),
                    row[columnNames[1]].ToString(),
                    row[columnNames[2]].ToString(),
                    Convert.ToDateTime(row[columnNames[3]].ToString()),
                    row[columnNames[4]].ToString(),
                    Int32.Parse(row[columnNames[5]].ToString()),
                    Int32.Parse(row[columnNames[6]].ToString()),
                    Int32.Parse(row[columnNames[7]].ToString()),
                    Int32.Parse(row[columnNames[8]].ToString()));
                foreach (string s in roleNames)
                {
                    if (sec.CheckUserInRole(tempEI.uName, s))
                    {
                        tempEI.role = s;
                    }
                }
                tempList.Add(JsonConvert.SerializeObject(tempEI));
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
        public JArray Post([FromBody]Employee_Info value)
        {
            security sec = new security();
            errorHandling employeeHandle = new errorHandling();
            List<errorMSG> returner = new List<errorMSG>();
            errorMSG errorMsg;
            JArray tempList = new JArray();
            returner = employeeHandle.iEmployeeEH(value);
            if (returner.Count == 0)
            {

                Person_Info tempPI = new Person_Info();
                DataTable tempDT = mDAL.sPerson(value.person_id.ToString());
                // POST / INSERT
                foreach (DataRow row in tempDT.Rows)
                {
                    tempPI = new Person_Info(
                        Int32.Parse(row[columnNames2[0]].ToString()),
                        row[columnNames2[1]].ToString(),
                        row[columnNames2[2]].ToString(),
                        row[columnNames2[3]].ToString(),
                        row[columnNames2[4]].ToString(),
                        row[columnNames2[5]].ToString(),
                        row[columnNames2[6]].ToString(),
                        row[columnNames2[7]].ToString(),
                        row[columnNames2[8]].ToString(),
                        row[columnNames2[9]].ToString());
                }
                // Adding the user to the membership stuff and all that 
                try
                {
                    MembershipCreateStatus status;
                    MembershipUser temp = Membership.CreateUser(value.uName, value.password, tempPI.email, "fav color", "Blue", true, out status);
                    if (status == MembershipCreateStatus.Success)
                    {
                        if (temp != null)
                        {
                            sec.UserToRole(value.uName, value.role);
                            if (value.dateOfTerm != "N/A")
                            {
                                mDAL.Employee(
                                    value.uName,
                                    "",
                                    value.dateOfHire.ToString(),
                                    value.dateOfTerm.ToString(),
                                    value.store_id.ToString(),
                                    value.company_id.ToString(),
                                    value.person_id.ToString());
                            }
                            else
                            {
                                mDAL.Employee(
                                    value.uName,
                                    "",
                                    value.dateOfHire.ToString(),
                                    "N/A",
                                    value.store_id.ToString(),
                                    value.company_id.ToString(),
                                    value.person_id.ToString());
                            }
                        }
                    }
                    else
                    {
                        returner.Add(errorMsg = new errorMSG(1, sec.GetErrorMessage(status)));
                    }

                }
                catch (MembershipCreateUserException e)
                {
                    returner.Add(errorMsg = new errorMSG(1, sec.GetErrorMessage(e.StatusCode)));
                }
                catch (Exception e)
                {
                    returner.Add(errorMsg = new errorMSG(1, e.Message));
                }
            }

            foreach (errorMSG em in returner)
            {
                tempList.Add(JsonConvert.SerializeObject(em));
            }

            return tempList;
        }




        // PUT api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Puts. </summary>
        ///

        ///
        /// <param name="empID">    The emp Identifier to delete. </param>
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An errorMSG. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public JArray Put(int empID, [FromBody]Employee_Info value)
        {
            security sec = new security();
            errorHandling employeeHandle = new errorHandling();
            List<errorMSG> returner = new List<errorMSG>();
            errorMSG errorMsg;
            JArray tempList = new JArray();

            if (value.password != "")
            {
                returner = employeeHandle.iEmployeeEH(value);
            }
            if (returner.Count == 0)
            {
                DataTable tempDT = mDAL.sEmployee(empID.ToString());
                if (tempDT.Rows.Count != 1)
                {
                    returner.Add(errorMsg = new errorMSG(1, "No employee Found with that ID"));
                }
                else
                {
                    try
                    {
                        string Test = tempDT.Rows[0]["username"].ToString();
                        MembershipUserCollection u = Membership.FindUsersByName(Test);// Getting the user name and all that fun stuff 
                        if (u.Count != 1)
                        {
                            returner.Add(errorMsg = new errorMSG(1, "Problem finding your username"));
                        }
                        else
                        {


                            try
                            {
                                if (value.password != "")
                                {
                                    MembershipUser mu = u[Test];
                                    if (mu.ChangePassword(mu.ResetPassword("Blue"), value.password))
                                    {
                                        // All good in the hood 
                                        mDAL.uEmployee(
                                                empID.ToString(),
                                                "",
                                                "",
                                                value.dateOfHire.ToString(),
                                                value.dateOfTerm.ToString(),
                                                value.store_id.ToString(),
                                                value.company_id.ToString(),
                                                value.person_id.ToString());

                                        sec.UpdateUserToRole(value.uName, value.role);
                                    }
                                    else
                                    {
                                        returner.Add(errorMsg = new errorMSG(1, "Could Not change password!"));
                                    }
                                }
                                else if (value.password == "")
                                {
                                    mDAL.uEmployee(
                                                    empID.ToString(),
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    value.store_id.ToString(),
                                                    value.company_id.ToString(),
                                                    "");


                                    sec.UpdateUserToRole(value.uName, value.role);

                                }
                            }
                            catch (MembershipPasswordException e)
                            {
                                returner.Add(errorMsg = new errorMSG(1, e.Message));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        returner.Add(errorMsg = new errorMSG(1, e.Message));
                    }
                }
            }



            foreach (errorMSG em in returner)
            {
                tempList.Add(JsonConvert.SerializeObject(em));
            }

            return tempList;

        }


        // DELETE api/Companies/5

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Deletes the given empID. </summary>
        ///

        ///
        /// <param name="empID">    The emp Identifier to delete. </param>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(string empID)
        {
            mDAL.dEmployee(empID);
        }

    }
}
