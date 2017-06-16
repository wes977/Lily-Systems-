/*
 File Name      :   EmployeePreference.cs
 Date           :   February 10, 2017
 Description    :   The employee preference class is responsible for dealing with the employee preferences of the users
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     This is the Employee Preference class containing the preferences of each employee.
    /// </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class EmployeePreference
    {
        /// <summary>   The start time. </summary>
        public DateTime startTime;
        /// <summary>   The end time. </summary>
        public DateTime endTime;
        /// <summary>   The day of week. </summary>
        public string dayOfWeek;
        /// <summary>   Identifier for the employee. </summary>
        public int employeeID;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     This is the constructor for the employee preference class using default values.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public EmployeePreference()
        {
            startTime = DateTime.MaxValue;
            endTime = DateTime.MinValue;
            dayOfWeek = "monday";

        }
    }
}