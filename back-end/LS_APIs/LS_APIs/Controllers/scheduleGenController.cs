///-------------------------------------------------------------------------------------------------
// file:	controllers\schedulegencontroller.cs
//
// summary:	Implements the schedulegencontroller class
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
using LS_APIs.ScheduleBuilder;

namespace LS_APIs.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling schedule generates. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class scheduleGenController : ApiController
    {
        /// <summary>   List of names of the columns. </summary>
        public static readonly string[] columnNames = {
            "shift_id",
            "startTime",
            "endTime",
            "employee_id",
            "schedule_id",
           };

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

            DataTable tempDT = mDAL.sShift();

            foreach (DataRow row in tempDT.Rows)
            {
                Shift_Info tempCI = new Shift_Info();
                tempCI.shift_id = Convert.ToInt32(row[columnNames[0]].ToString());
                tempCI.startTime = Convert.ToDateTime(row[columnNames[1]].ToString());
                tempCI.endTime = Convert.ToDateTime(row[columnNames[2]].ToString());
                if (row[columnNames[3]].ToString() != "")
                {
                    tempCI.employee_id = Convert.ToInt32(row[columnNames[3]].ToString());
                }
                tempCI.schedule_id = Convert.ToInt32(row[columnNames[4]].ToString());
                // tempCI.schedule_id = Convert.ToInt32(row["schedule_id"].ToString());


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

            DataTable tempDT = mDAL.sShift(id.ToString());

            foreach (DataRow row in tempDT.Rows)
            {
                Shift_Info tempCI = new Shift_Info();
                tempCI.shift_id = Convert.ToInt32(row[columnNames[0]].ToString());
                tempCI.startTime = Convert.ToDateTime(row[columnNames[1]].ToString());
                tempCI.endTime = Convert.ToDateTime(row[columnNames[2]].ToString());
                if (row[columnNames[3]].ToString() != "")
                {
                    tempCI.employee_id = Convert.ToInt32(row[columnNames[3]].ToString());
                }
                tempCI.schedule_id = Convert.ToInt32(row[columnNames[4]].ToString());
                // tempCI.schedule_id = Convert.ToInt32(row["schedule_id"].ToString());


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
        /// <returns>   A JArray. </returns>
        ///-------------------------------------------------------------------------------------------------

        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public JArray Post([FromBody]Shift_Info value)
        {
            JArray tempList = new JArray();
            ScheduleBuilder.ScheduleBuilder SB = new ScheduleBuilder.ScheduleBuilder();
            DateTime sTime = new DateTime(value.startTime.Year, value.startTime.Month, value.startTime.Day);
            DateTime eTime = new DateTime(value.endTime.Year,value.endTime.Month,value.endTime.Day);

            List<errorMSG> returner = new List<errorMSG>();
            errorMSG errorMsg;



                   
                    List<string> tempStringLeist = new List<string>();
            tempStringLeist = SB.buildEmployeeSchedule(sTime, eTime,value.store_id,value.employee_id);
            
            foreach (string s in tempStringLeist)
            {
                returner.Add(errorMsg = new errorMSG(1, s));
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
            mDAL.uShift(id.ToString(), value.startTime.ToString(), value.endTime.ToString(), value.employee_id.ToString(), "");
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
            mDAL.dShift(id.ToString());
        }
    }
}
