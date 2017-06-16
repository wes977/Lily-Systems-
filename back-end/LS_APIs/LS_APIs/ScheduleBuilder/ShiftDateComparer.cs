/*
 File Name      :   ShiftDateComparer.cs
 Date           :   February 10, 2017
 Description    :   The shift comparer class contains the logic in ensuring that each shift is being appropriately placed into the calendar with no shifts starting or ending oddly.  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     This is the Shift date comparer class containing all of the logic for shifts.
    /// </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ShiftDateComparer : IComparer<Shift>
    {
        #region IComparer<shift> Members

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Compares two shifts together too ensure that all shifts are calculated properly.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="shift1">   contains the shift object that is being taken from the list for
        ///                         consideration. </param>
        /// <param name="shift2">   contains the shift object that is being taken from the list for
        ///                         consideration. </param>
        ///
        /// <returns>   int returnValue: a flag stating if the shifts are the same. </returns>
        ///-------------------------------------------------------------------------------------------------

        public int Compare(Shift shift1, Shift shift2)
        {
            int returnValue = 1;
            if (shift1 != null && shift2 == null)
            {
                returnValue = 0;
            }
            else if (shift1 == null && shift2 != null)
            {
                returnValue = 0;
            }
            else if (shift1 != null && shift2 != null)
            {
                if (shift1.startDateTime.Equals(shift2.startDateTime))
                {
                    returnValue = shift1.endDateTime.CompareTo(shift2.endDateTime);
                }
                else
                {
                    returnValue = shift1.startDateTime.CompareTo(shift2.startDateTime);
                }
            }
            return returnValue;
        }

        #endregion
    }
}