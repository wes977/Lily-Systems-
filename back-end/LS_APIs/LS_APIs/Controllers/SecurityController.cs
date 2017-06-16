///-------------------------------------------------------------------------------------------------
// file:	Controllers\SecurityController.cs
//
// summary:	Implements the security controller class
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
using System.Web.Security;
namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling securities. </summary>
    ///
    
    ///-------------------------------------------------------------------------------------------------

    public class SecurityController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames =
            {
            "employee_id",
            "username",
            "password",
            "dateOfHire",
            "dateOfTermination",
            "store_id",
            "company_id",
            "person_id",
            "active"
        };
        /// <summary>   The column names ei. </summary>
        public static readonly string[] columnNamesEI = { "employee_id", "username", "password", "dateOfHire", "dateOfTermination", "store_id", "company_id", "person_id", "active" };

        /// <summary>   List of names of the roles. </summary>
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
        // POST api/Companies

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Post this message.  This one returns the role and all that fun stuff and logs you in if you are in the DB</summary>
        ///
        
        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public JArray Post([FromBody]Employee_Info value)
        {

            JArray tempList = new JArray();
            security sec = new security();
            bool loggedIn = sec.ValidateUserLogin(value.uName, value.password);
            string returner = "";
            if (loggedIn)
            {
                foreach (string str in roleNames)
                {
                    if (sec.CheckUserInRole(value.uName, str))
                    {
                        value.role = str;
                        break;
                    }
                }
                value.password = "";
                // value.role = "Super Admin";
                tempList.Add(JsonConvert.SerializeObject(value));
            }
            else
            {
                value.role = "Failer";
                tempList.Add(JsonConvert.SerializeObject(value));
            }
            return tempList;
        }


        // This returns all the higher up people and all that fun stuff 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a j array using the given emp identifier. </summary>
        ///
        
        ///
        /// <param name="empID">    The emp Identifier to get. </param>
        ///
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public JArray Get(int empID)
        {
            JArray tempList = new JArray();
            Employee_Info userEI = new Employee_Info();
            DataTable tempDT = mDAL.sEmployee(empID.ToString());
            security sec = new security();
            foreach (DataRow row in tempDT.Rows)
            {
                userEI = new Employee_Info(
                    Int32.Parse(row[columnNamesEI[0]].ToString()),
                    row[columnNamesEI[1]].ToString(),
                    row[columnNamesEI[2]].ToString(),
                    Convert.ToDateTime(row[columnNamesEI[3]].ToString()),
                    row[columnNamesEI[4]].ToString(),
                    Int32.Parse(row[columnNamesEI[5]].ToString()),
                    Int32.Parse(row[columnNamesEI[6]].ToString()),
                    Int32.Parse(row[columnNamesEI[7]].ToString()),
                    Int32.Parse(row[columnNamesEI[8]].ToString()));
            }
            tempDT = mDAL.sEmployee();
            foreach (DataRow row in tempDT.Rows)
            {
                Employee_Info tempEI = new Employee_Info(
                    Int32.Parse(row[columnNamesEI[0]].ToString()),
                    row[columnNamesEI[1]].ToString(),
                    row[columnNamesEI[2]].ToString(),
                    Convert.ToDateTime(row[columnNamesEI[3]].ToString()),
                    row[columnNamesEI[4]].ToString(),
                    Int32.Parse(row[columnNamesEI[5]].ToString()),
                    Int32.Parse(row[columnNamesEI[6]].ToString()),
                    Int32.Parse(row[columnNamesEI[7]].ToString()),
                    Int32.Parse(row[columnNamesEI[8]].ToString()));

                if (tempEI.company_id == userEI.company_id &&
                    tempEI.store_id == userEI.store_id &&
                    tempEI.active == 1)
                {
                    if (sec.CheckUserInRole(tempEI.uName, roleNames[1]))
                    {
                        tempEI.role = roleNames[1];
                        tempList.Add(JsonConvert.SerializeObject(tempEI));
                    }
                    else if (sec.CheckUserInRole(tempEI.uName, roleNames[2]))
                    {
                        tempEI.role = roleNames[2];
                        tempList.Add(JsonConvert.SerializeObject(tempEI));
                    }
                   else  if (sec.CheckUserInRole(tempEI.uName, roleNames[3]))
                    {
                        tempEI.role = roleNames[3];
                        tempList.Add(JsonConvert.SerializeObject(tempEI));
                    }
                }
            }
            return tempList;
        }
    }
}