/*
 File Name      :       SchedulePrint.cs
 Date           :       March 15, 2017
 Description    :       Gets the appropriate information in a datetable thats needed to create a downloadable schedule.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace LS_APIs.SchedulePrinter
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A schedule print. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class SchedulePrint
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the schedule body information. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="scheduleId">   Id of schedule. </param>
        ///
        /// <returns>   DataTable - table of schedule information for schedule id. </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable GetSchedule(string scheduleId)
        {
            DataTable dt = new DataTable();
            string command = "SELECT c.firstName + ' ' + c.lastName AS Name, " +
                                    "CONVERT(varchar(15), CAST(a.startTime AS Date), 100) AS Date, " +
                                    "CONVERT(varchar(15), CAST(a.startTime AS TIME), 100) AS 'Start Time', " +
	                                "CONVERT(varchar(15), CAST(a.endTime AS TIME), 100) AS 'End Time', " + 
	                                "DATEDIFF(hh, a.startTime, a.endTime) AS 'Length (hrs)' " +
                            "FROM Shift_Info a INNER JOIN Employee_Info b " +
                            "ON a.employee_id = b.employee_id INNER JOIN Person_Info c " +
                            "ON b.person_id = c.person_id " +
                            //scheduleId is not coming directly from a user input field, but from
                            //another method call and is validated first. Sql Injection is less of
                            //a risk.
                            "WHERE b.store_id = '" + scheduleId + "'";

            LS_APIs.DAL.ModularDAL dal = new DAL.ModularDAL();
            dt = dal.Select(command);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the schedule header information, ie company name and address that appears above the
        ///     schedule to give it information about what the schedule is about and for.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="scheduleID">   Id of schedule. </param>
        ///
        /// <returns>
        ///     DateTable - table containing information about the company the schedule is for.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public DataTable GetScheduleHeader(string scheduleID)
        {
            DataTable dt = new DataTable();
            string command = "SELECT b.companyName AS 'Company Name', " +
                                "a.storeAddress + ', ' + a.city + ', ' + a.country AS Address, " +
                                "a.storePhone AS 'Phone #' " +
                                "FROM Store_Info a INNER JOIN Company_Info b " +
                                "ON a.company_id = b.company_id " + 
                                //scheduleId is not coming directly from a user input field, but from
                                //another method call and is validated first. Sql Injection is less of
                                //a risk.
                                "WHERE a.store_id = '" + scheduleID + "'";

            LS_APIs.DAL.ModularDAL dal = new DAL.ModularDAL();
            dt = dal.Select(command);

            return dt;
        }
    }
}