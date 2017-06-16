///-------------------------------------------------------------------------------------------------
// file:	Controllers\MessengerController.cs
//
// summary:	Implements the messenger controller class
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
using LS_APIs;

namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling messengers. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class MessengerController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = { "Message_ID", "Sender_ID", "Receiver_ID", "Subject_Line", "Words", "messageDate", "shiftReq" };
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
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   A mDAL. </returns>
        ///-------------------------------------------------------------------------------------------------

        private Logic mDAL = new Logic();


        // GETs all th email for a user and all that fun stuff 

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
            DataTable tempDT = new DataTable();
            if (id < 0)
            {
                id = id * (-1);
                tempDT = mDAL.sentMail(id.ToString());
            }
            else
            {
                tempDT = mDAL.sMessenger(id.ToString());
            }



            foreach (DataRow row in tempDT.Rows)
            {
                Messenger tempCI;
                if (row[columnNames[6]].ToString() != "" )
                {
                     tempCI = new Messenger(
                        Int32.Parse(row[columnNames[0]].ToString()),
                        Int32.Parse(row[columnNames[1]].ToString()),
                        Int32.Parse(row[columnNames[2]].ToString()),
                        row[columnNames[3]].ToString(),
                        row[columnNames[4]].ToString(),
                        Convert.ToDateTime(row[columnNames[5]].ToString()),
                       Int32.Parse(row[columnNames[6]].ToString()));
                }
                else
                {
                    tempCI = new Messenger(
                        Int32.Parse(row[columnNames[0]].ToString()),
                        Int32.Parse(row[columnNames[1]].ToString()),
                        Int32.Parse(row[columnNames[2]].ToString()),
                        row[columnNames[3]].ToString(),
                        row[columnNames[4]].ToString(),
                        Convert.ToDateTime(row[columnNames[5]].ToString()));
                }
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
        public void Post([FromBody]Messenger value)
        {
            if (value.shiftReq == 0)
            {
                mDAL.Messenger(value.Sender_ID, value.Rec_ID, value.Subject, value.Words, value.messageDate);
            }
        }

        //  SENDs a message to all the higher up and all that fun stuff 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Puts. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="empID">    Identifier for the emp. </param>
        /// <param name="tempMSG">  Message describing the temporary. </param>
        ///
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public JArray Put(int empID, [FromBody]Messenger tempMSG)
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


                    if (sec.CheckUserInRole(tempEI.uName, roleNames[1]) ||
                        sec.CheckUserInRole(tempEI.uName, roleNames[2]) ||
                        sec.CheckUserInRole(tempEI.uName, roleNames[3]))
                    {

                            mDAL.Messenger((userEI.employee_id), tempEI.employee_id, tempMSG.Subject, tempMSG.Words, tempMSG.messageDate , tempMSG.shiftReq);
                            Notifications not = new Notifications();
                            not.SendShiftRequestSMS(userEI.uName+ " "+tempMSG.Words + " (Text no@" + userEI.employee_id + " to decline or yes@" + userEI.employee_id + "@" + tempMSG.Subject.Split(' ').Last() + ")");
                        
                    }
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
            mDAL.dMessenger(id.ToString());
        }
    }
}