/*
 File Name      :   Calendar.cs
 Date           :   February 10, 2017
 Description    :   The calendar class is responsible for dealing with the shifts and organizing them into a list. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     This is the Calendar class containing the list of shifts and methods for shifts.
    /// </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Calendar
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   The lists. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <typeparam name="Shift">    Type of the shift. </typeparam>
        ///
        /// <returns>   The shifts. </returns>
        ///-------------------------------------------------------------------------------------------------

        List<Shift> shifts = new List<Shift>();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the list. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <typeparam name="ShiftWarning"> Type of the shift warning. </typeparam>
        ///
        /// <returns>   The shiftWarnings. </returns>
        ///-------------------------------------------------------------------------------------------------

        List<ShiftWarning> shiftWarnings = new List<ShiftWarning>();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   adds a shift to the list. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="shift">    contains the shift object that is being added to the list. </param>
        ///
        /// <returns>   string flag: says the shfit has been added to the list. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string addShift(Shift shift)
        {
            string flag = "Inserted shift";
            shifts.Add(shift);

            return flag;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   adds a warnings to the list. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="warning">  contains the warning object that is being added to the list. </param>
        ///-------------------------------------------------------------------------------------------------

        public void addWarning(ShiftWarning warning)
        {
            shiftWarnings.Add(warning);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   removes a shift from the list. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="shift">    contains the shift object that is being removed from the list. </param>
        ///
        /// <returns>   string flag: says the shfit has been removed from the list. </returns>
        ///-------------------------------------------------------------------------------------------------

        public string removeShift(Shift shift)
        {
            string flag = "Removed shift";

            for (int i = 0; i < shifts.Count; i++)
            {
                if (shifts[i].shiftID == shift.shiftID)
                {
                    shifts.RemoveAt(i);
                    break;
                }
            }

            return flag;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all shifts from the list. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>   List of shifts called shifts: returns all of the shifts from the list. </returns>
        ///-------------------------------------------------------------------------------------------------

        public List<Shift> getShifts()
        {
            return shifts;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all warnings from the list. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <returns>
        ///     List of ShiftWarning called shiftWarnings: returns all of the warnings from the list.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public List<ShiftWarning> getWarning()
        {
            return shiftWarnings;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets shifts from the list based off of time. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="time"> contains the datetime that the shift would match. </param>
        ///
        /// <returns>
        ///     List of shifts called shiftTimes: returns a list of shifts that match to the times given.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public List<Shift> getShiftAtTime(DateTime time)
        {
            List<Shift> shiftTimes = new List<Shift>();
            foreach (Shift Shift in shifts)
            {
                if (Shift.startDateTime <= time && Shift.endDateTime > time)
                {
                    shiftTimes.Add(Shift);
                }
            }
            return shiftTimes;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets shifts from the list based off of the day. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="dateTime"> contains the datetime that the shift would match. </param>
        ///
        /// <returns>
        ///     List of shifts called shiftTimes: returns a list of shifts that match to the times given.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public List<Shift> getShiftsForDay(DateTime dateTime)
        {
            List<Shift> shiftTimes = new List<Shift>();
            DateTime date = dateTime - new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
            foreach (Shift Shift in shifts)
            {
                //check start time
                if (Shift.startDateTime >= date && Shift.startDateTime < date + new TimeSpan(24, 0, 0))
                {
                    shiftTimes.Add(Shift);
                }
                //check end time
                else if (Shift.endDateTime > date && Shift.endDateTime <= date + new TimeSpan(24, 0, 0))
                {
                    shiftTimes.Add(Shift);
                }
            }
            return shiftTimes;
        }
    }
}