/*
 File Name      :   ShiftWarning.cs
 Date           :   February 10, 2017
 Description    :   The shift class containing all of the functions related to shift warnings  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     This is the Shift warning class containing all of the logic for shift warnings.
    /// </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ShiftWarning
    {
        /// <summary>   Identifier for the company. </summary>
        public int companyID;
        /// <summary>   Identifier for the store. </summary>
        public int storeID;
        /// <summary>   The start date time. </summary>
        public DateTime startDateTime;
        /// <summary>   The end date time. </summary>
        public DateTime endDateTime;

        /// <summary>   The warning level. </summary>
        public int warningLevel;
        /// <summary>   The warning. </summary>
        public string warning;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Shift warning constructor with data to be initialized with. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="companyID">        ID of company. </param>
        /// <param name="storeID">          ID of store. </param>
        /// <param name="startDateTime">    the start date time for the shift. </param>
        /// <param name="endDateTime">      the end date time for the shift. </param>
        /// <param name="warningLevel">     states the level of the warning. </param>
        /// <param name="warning">          contains the warning as a string. </param>
        ///-------------------------------------------------------------------------------------------------

        public ShiftWarning(int companyID, int storeID, DateTime startDateTime, DateTime endDateTime, int warningLevel, string warning)
        {
            this.companyID = companyID;
            this.storeID = storeID;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.warningLevel = warningLevel;
            this.warning = warning;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Override of the ToString function to contain the shift warning information.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   returns a string containing the information of the shift warning object. </returns>
        ///-------------------------------------------------------------------------------------------------

        public override string ToString()
        {
            return "Shift Warning " + " From " + startDateTime + " To " + endDateTime + ". Warning: " + warning;
        }
    }
}