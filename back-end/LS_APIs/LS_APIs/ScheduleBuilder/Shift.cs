/*
 File Name      :   Shift.cs
 Date           :   February 10, 2017
 Description    :   The shift class containing all of the functions related to shifts.  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   This is the Shift class containing all of the logic for shifts. </summary>
    ///
    /// <remarks>   Jennifer, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Shift
    {
        /// <summary>   Variables. </summary>
        public int employeeID;
        public int CompanyID;
        public int StoreID;
        /// <summary>   Identifier for the shift. </summary>
        public int shiftID;
        /// <summary>   The start date time. </summary>
        public DateTime startDateTime;
        /// <summary>   The end date time. </summary>
        public DateTime endDateTime;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor for the shift class. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public Shift()
        {
            employeeID = 0;
            CompanyID = 0;
            StoreID = 0;
            shiftID = 0;
            startDateTime = DateTime.MinValue;
            endDateTime = DateTime.MinValue;
        }


        /// <summary>
        /// Shift constructor with data to be initialized with
        /// </summary>
        /// 
        /// <remarks>   Jeniffer, 2017-04-17. </remarks>
        /// 
        /// <param name="employeeID">ID of employee</param>
        /// <param name="branchID">ID of branch</param>
        /// <param name="startDateTime">the start date time for the shift</param>
        /// <param name="endDateTime">the end date time for the shift</param>
        public Shift(int employeeID, int StoreID, int CompanyID, DateTime startDateTime, DateTime endDateTime)
        {
            this.employeeID = employeeID;
            this.StoreID = StoreID;
            this.CompanyID = CompanyID;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            shiftID = 0;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Override of the ToString function to contain the shift information. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   returns a string containing the information of the shift object. </returns>
        ///-------------------------------------------------------------------------------------------------

        public override string ToString()
        {
            return "Shift: " + employeeID + " " + StoreID + " " + CompanyID + " " + shiftID + " " + startDateTime + " " + endDateTime + " " + (endDateTime - startDateTime);
        }
    }
}