/*
 File Name      :   ScheduleBuilder.cs
 Date           :   February 10, 2017
 Description    :   All of the auto scheduling and logic of the schedule builder is here. All shifts are pulled together and evaluated according to preferences and dates and employees. 
 */
using LS_APIs.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;


namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     This is the ScheduleBuilder class containing all of the logic for building the schedules.
    /// </summary>
    ///
    /// <remarks>   Jennifer, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ScheduleBuilder
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Selects an employee from the list and fits the employees according to their preferences
        ///     and the required times that need to be filled accordingly.
        /// </summary>
        ///
        /// <remarks>   Jennifer, 2017-04-17. </remarks>
        ///
        /// <param name="cdl">          contains the calendar object that is being taken from the list
        ///                             for consideration. </param>
        /// <param name="shiftTime">    contains the datetime that needs to be filled. </param>
        /// <param name="empShiftPref"> contains the Employee Preference object that is being taken from
        ///                             the list for consideration. </param>
        ///
        /// <returns>
        ///     EmployeePreference selectedShiftPreference: cotains the shift preference with the
        ///     employee that matches to the need.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        private EmployeePreference selectEmployeeForShift(Calendar cdl, DateTime shiftTime, List<EmployeePreference> empShiftPref)
        {
            List<Shift> currentShifts = new List<Shift>();
            EmployeePreference selectedShiftPreference = null;
            currentShifts = cdl.getShiftsForDay(shiftTime);
            CultureInfo provider = CultureInfo.InvariantCulture;
            Random rand = new Random();
            List<EmployeePreference> empShiftPrefList = new List<EmployeePreference>(empShiftPref);
            bool employeeValid = false;
            int stage = 0;

            //get a valid employee
            do
            {
                selectedShiftPreference = null;

                if (stage == 0)
                {
                    //find an employee who wants to work that shift
                    while (empShiftPrefList.Count > 0 && selectedShiftPreference == null)
                    {
                        //select random shift preferance
                        int randEmpIndex = rand.Next(empShiftPrefList.Count);

                        selectedShiftPreference = empShiftPrefList[randEmpIndex];

                        //if shift want to work at midnight, remove it and find another
                        DateTime midnight = DateTime.ParseExact("00", "HH", provider);
                        if (selectedShiftPreference.startTime <= midnight)
                        {
                            empShiftPrefList.Remove(selectedShiftPreference);
                            selectedShiftPreference = null;
                        }
                    }
                    if (empShiftPrefList.Count == 0)
                    {
                        //reset list for next stage
                        empShiftPrefList = new List<EmployeePreference>(empShiftPref);
                        stage = 1;
                    }
                }

                else if (stage == 1)
                {
                    //find an employee fo wants to work that day
                    //find an employee who wants to work that shift
                    while (empShiftPrefList.Count > 0 && selectedShiftPreference == null)
                    {
                        //select random shift preferance
                        int randEmpIndex = rand.Next(empShiftPrefList.Count);
                        selectedShiftPreference = empShiftPrefList[randEmpIndex];

                        //if shift want to work at midnight, remove it and find another
                        DateTime midnight = DateTime.ParseExact("00", "HH", provider);
                        if (selectedShiftPreference.startTime != midnight)
                        {
                            empShiftPrefList.Remove(selectedShiftPreference);
                            selectedShiftPreference = null;
                        }
                    }
                }


                //check if employee selected is valid
                employeeValid = true;

                //if there is greater than 4 hours left in the day and employee doesnt want to work longer that 4 hours
                if (selectedShiftPreference == null || shiftTime.Hour < 20 && selectedShiftPreference.endTime.Hour - shiftTime.Hour < 4)
                {
                    //emp doesnt want to work long enough for shift
                    employeeValid = false;
                }
                else
                {
                    //check if they are already working that day
                    foreach (Shift currShift in currentShifts)
                    {
                        //if employee found in another shift that day
                        if (currShift.employeeID == selectedShiftPreference.employeeID)
                        {
                            //employee not valid
                            employeeValid = false;
                            break;
                        }
                    }
                }

                //remove prefference from list so it cant be checked again
                if (selectedShiftPreference != null)
                {
                    empShiftPrefList.Remove(selectedShiftPreference);
                }

                if (stage == 1 && empShiftPrefList.Count == 0)
                {
                    return null;
                }

            } while (!employeeValid);//end get a valid employee

            return selectedShiftPreference;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Builds the actual schedule based off of the range date and store and company.
        /// </summary>
        ///
        /// <remarks>   Jennifer, 2017-04-17. </remarks>
        /// <param name="startDate">contains the start date that the schedule will start to fill with</param>
        /// <param name="endDate">contains the end date that the schedule will start to fill with</param>
        /// <param name="storeID">ID of store</param>
        /// <param name="companyID">ID of company</param>
        /// <returns>int scheduleWasBuilt: a flag that states that the schedule has been succesfully built</returns>
        public List<string> buildEmployeeSchedule(DateTime startDate, DateTime endDate, int storeID, int companyID)
        {
            //int scheduleWasBuilt = 0;
            List<string> Warnings = new List<string>();
            Logic lg = new Logic();
            Calendar cdl = new Calendar();
            DateTime shiftDate = startDate;

            try//check the userCredentials and get the employee ID
            {

                //string empid, string fname, string lname, string phone, string email, string user, string strid, string cmpyid, string act
                //get all employees from company/store that we are builing schedule
                DataTable tempDT = lg.sEmployeeJoinPersonBuildSchedule("", "", "", storeID.ToString(), companyID.ToString());

                //creted a list to store all of the stores employees
                List<Employee> allEmp = new List<Employee>();

                //go through the list of employees from the databas and add them to out list of employees
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    Employee tempEmp = new Employee();
                    tempEmp.employeeID = Convert.ToInt32(tempDT.Rows[i]["employee_id"]);
                    tempEmp.employeeFirstName = tempDT.Rows[i]["firstName"].ToString();
                    tempEmp.employeeLastName = tempDT.Rows[i]["lastName"].ToString();
                    tempEmp.storeID = Convert.ToInt32(tempDT.Rows[i]["store_id"]);
                    tempEmp.companyID = Convert.ToInt32(tempDT.Rows[i]["company_id"]);
                    tempEmp.employeeType = EMPLOYEE_TYPE.FULL_TIME;
                    allEmp.Add(tempEmp);
                }

                //create a list to hold a tuple of (hour, #employees required to work). This list will have the hours from 0 to 23
                List<Tuple<int, int>> empsPerHour = new List<Tuple<int, int>>();
                empsPerHour = numOfEmpsPerHour();

                bool flag = false; //flag set true if the current schedule is touched

                //loop untill day schedule valid(no changes made)
                while (flag == false)
                {
                    flag = true;

                    //loop through each hour of the schedule
                    shiftDate = startDate;
                    while (shiftDate < endDate)
                    {
                        //Console.WriteLine("Shift Time = " + shiftDate);
                        int numEmpsRequired = 0;
                        //get how many emolpyees needed
                        foreach (Tuple<int, int> hour in empsPerHour)
                        {
                            if (hour.Item1 == shiftDate.Hour)
                            {
                                numEmpsRequired = hour.Item2;
                            }
                        }

                        //get shift prefferences of employees that want to work for this shift
                        DataTable tempShiftPreferences = lg.sShiftPreferences(shiftDate.DayOfWeek.ToString().ToLower(), shiftDate.Hour + ":00:00");

                        List<EmployeePreference> empShiftPref = new List<EmployeePreference>();

                        //put the shift prefferences into a list of prefferences
                        for (int i = 0; i < tempShiftPreferences.Rows.Count; i++)
                        {
                            CultureInfo provider = CultureInfo.InvariantCulture;
                            EmployeePreference tempEmpP = new EmployeePreference();
                            tempEmpP.employeeID = Convert.ToInt32(tempShiftPreferences.Rows[i]["employee_id"]);
                            tempEmpP.dayOfWeek = tempShiftPreferences.Rows[i]["day"].ToString();
                            tempEmpP.startTime = DateTime.ParseExact(tempShiftPreferences.Rows[i]["startTime"].ToString(), "HH:mm:ss", provider);
                            tempEmpP.endTime = DateTime.ParseExact(tempShiftPreferences.Rows[i]["endTime"].ToString(), "HH:mm:ss", provider);
                            empShiftPref.Add(tempEmpP);
                        }

                        //create a dateTime for the shift time we want to fill
                        DateTime shiftStartIme = new DateTime(shiftDate.Year, shiftDate.Month, shiftDate.Day, shiftDate.Hour, 0, 0);

                        //calculate the difference between #emps scheduled and #emps rewuired
                        int difference = (numEmpsRequired - cdl.getShiftAtTime(shiftStartIme).Count);

                        //if short employees, add an employee
                        while (difference > 0)
                        {
                            EmployeePreference selectedShiftPreference = selectEmployeeForShift(cdl, shiftStartIme, empShiftPref);
                            //if returns null, no one want to work the shift
                            if (selectedShiftPreference == null)
                            {
                                //decided if pick a random empolyee or leave blank 
                                ShiftWarning warning = new ShiftWarning(storeID, companyID, shiftStartIme, shiftStartIme + new TimeSpan(0, 59, 59), 1, "Not enough employees for shift");
                                cdl.addWarning(warning);
                                //for now leave shift short
                                break;
                            }

                            //find employee object for selected employee (from emp ID)
                            Employee shiftEmpObj = new Employee();
                            foreach (Employee emp in allEmp)
                            {
                                if (selectedShiftPreference.employeeID == emp.employeeID)
                                {
                                    shiftEmpObj = emp;
                                }
                            }
                            //add the date of the shift to the preffered end time
                            TimeSpan timeOfDay = selectedShiftPreference.endTime.TimeOfDay;
                            DateTime preferedEndTime = endDate.Date.Add(timeOfDay);

                            //create shift object for shift thats going to be added
                            Shift Shift = new Shift(shiftEmpObj.employeeID, shiftEmpObj.storeID, shiftEmpObj.companyID, shiftStartIme, preferedEndTime);

                            //add shift to calandar
                            cdl.addShift(Shift);
                            difference--;
                            flag = false;
                        }

                        //move to next hour
                        shiftDate = shiftDate.AddHours(1);
                    }

                    //check if to many employees are working. if so, end the shifts that are the longest
                    //foreach (Tuple<int, int> hour in empsPerHour)
                    shiftDate = startDate;
                    while (shiftDate < endDate)
                    {
                        //loop through each hour
                        //create a date object for current hour that is being checked
                        DateTime tempDate = new DateTime(shiftDate.Year, shiftDate.Month, shiftDate.Day, shiftDate.Hour, 0, 0);

                        int numEmpsRequired = 0;
                        //get how many emolpyees needed
                        foreach (Tuple<int, int> hour in empsPerHour)
                        {
                            if (hour.Item1 == shiftDate.Hour)
                            {
                                numEmpsRequired = hour.Item2;
                            }
                        }

                        //get all shifts working at time being checked
                        List<Shift> workingShifts = cdl.getShiftAtTime(tempDate);
                        int difference = (numEmpsRequired - workingShifts.Count);
                        //if more employees than reqired working
                        while (difference < 0)
                        {
                            //find the employee that has been working longest
                            Shift longestShift = null;
                            foreach (Shift shift in workingShifts)
                            {
                                if (longestShift == null || shift.startDateTime > longestShift.startDateTime)
                                {
                                    longestShift = shift;
                                }
                            }

                            TimeSpan shiftLength = tempDate - longestShift.startDateTime;

                            //check if been working greater than the minimum shift length
                            TimeSpan minShiftLength = new TimeSpan(4, 0, 0);
                            if (shiftLength > minShiftLength)
                            {
                                //if meets all requirements, set shift end time to current time
                                longestShift.endDateTime = tempDate;
                                difference++;
                                //changed a shift, set done flage to false
                                flag = false;
                            }
                            else
                            {
                                //longest shift not long enough, shift will have to many employees
                                break;
                            }

                        }
                        shiftDate = shiftDate.AddHours(1);
                    }

                    //get all shifts from calandar
                    List<Shift> allShifts = cdl.getShifts();

                    //check that all shifts are 8 hours long or shorter
                    foreach (Shift Shift in allShifts)
                    {
                        //loop through each shift and check length
                        TimeSpan shiftLength = Shift.endDateTime - Shift.startDateTime;
                        TimeSpan MaxShiftLength = new TimeSpan(8, 0, 0);

                        //if length greater than max shift length, change end time to max shift length time
                        if (shiftLength > MaxShiftLength)
                        {
                            //set end time to 8 hours after shift start
                            Shift.endDateTime = Shift.startDateTime + MaxShiftLength;
                            //changed a shift, set done flage to false
                            flag = false;
                        }
                    }

                }

                //get and display all shifts for debuging
                List<Shift> allShiftsDebug = cdl.getShifts();
                allShiftsDebug.Sort(new ShiftDateComparer());

                foreach (Shift shift in allShiftsDebug)
                {
                    lg.Shift(shift.employeeID.ToString(), shift.startDateTime, shift.endDateTime, shift.shiftID.ToString(), shift.StoreID.ToString());
                }


                List<ShiftWarning> allShiftWarnings = cdl.getWarning();
                allShiftWarnings.Sort(new ShiftWarningDateComparer());
                foreach (ShiftWarning warning in allShiftWarnings)
                {
                    Warnings.Add(warning.ToString());
                    //lg.ShiftWarnings(warning);
                }

                //compare required employees to employees scheduled
                shiftDate = startDate;
                while (shiftDate < endDate)
                {
                    foreach (Tuple<int, int> hour in empsPerHour)
                    {
                        if (hour.Item1 == shiftDate.Hour)
                        {
                            break;
                        }
                    }
                    shiftDate = shiftDate.AddHours(1);
                }
            }
            catch (Exception e)
            {
                //handle error
            }

            return Warnings;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the number of employees required per hour in order to populate the schedule
        ///     appropriately.
        /// </summary>
        ///
        /// <remarks>   Jennifer, 2017-04-17. </remarks>
        ///
        /// <returns>   List of employees per hour. </returns>
        ///-------------------------------------------------------------------------------------------------

        public List<Tuple<int, int>> numOfEmpsPerHour()
        {
            List<Tuple<int, int>> empsPerHour = new List<Tuple<int, int>>();
            Logic lg = new Logic();
            DataTable dt = new DataTable();
            List<double> tempEmpsPerHour = new List<double>();
            dt = lg.sSalesPerHour();

            foreach (DataRow dataRow in dt.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    tempEmpsPerHour.Add(Convert.ToDouble(item));
                }
            }


            int saleNum = 0;
            saleNum = lg.getSalesDivider();
            int count = 0;

            foreach (double sale in tempEmpsPerHour)
            {
                int number = (int)(Math.Round(sale / saleNum));
                if (number < 1)
                {
                    number = 1;
                }
                empsPerHour.Add(new Tuple<int, int>(count, number));
                count++;
            }
            return empsPerHour;
        }
    }
}