/*
 File Name      :       Notifications.cs
 Date           :       March 31, 2017
 Description    :       The notifications class notifies employees about upcoming shifts.
                        Text message notitifications are sent 24hrs before a shift begins.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using System.Data;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace LS_APIs
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A notifications. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Notifications
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the minute. </summary>
        ///
        /// <value> The minute. </value>
        ///-------------------------------------------------------------------------------------------------

        static int lastHour = DateTime.Now.Minute;
        /// <summary>   The timer. </summary>
        static System.Timers.Timer aTimer;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     NotificationMain is called on startup and triggers a onTimedEvent call every second.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public void NotificationMain()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;

            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     OnTimedEvent gets called every second and every minute thats passed the shifts are
        ///     checked in the db and any shifts that occur at that time one day ahead are recorded and
        ///     employees who own those shifts are sent a text alert.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="source">   . </param>
        /// <param name="e">        . </param>
        ///-------------------------------------------------------------------------------------------------

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (lastHour < DateTime.Now.Minute || (lastHour == 59 && DateTime.Now.Minute == 0))
            {
                lastHour = DateTime.Now.Minute;
                DataTable dt = CheckShifts(DateTime.Now.AddDays(1));
                string eid = "";

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        eid = row[column].ToString();
                        //foreach employee id in the datatable, get the employees phone number
                        //send the employee a text notification
                        SendSMS(GetPhoneNumber(eid));
                    }
                }
            }

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the employee ids of all shifts that occur at the time one day ahead. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="now">  . </param>
        ///
        /// <returns>   DataTable - employee id of all shifts occuring one day ahead. </returns>
        ///-------------------------------------------------------------------------------------------------

        static DataTable CheckShifts(DateTime now)
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT employee_id FROM Shift_Info WHERE startTime = '" + now.ToString() + "'";

            LS_APIs.DAL.ModularDAL dal = new LS_APIs.DAL.ModularDAL();

                dt = dal.Select(cmd);

            return dt;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the phone number of every employee with a shift occuring one day ahead of current
        ///     time.
        /// </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="eid">  . </param>
        ///
        /// <returns>   string - phone number. </returns>
        ///-------------------------------------------------------------------------------------------------

        static string GetPhoneNumber(string eid)
        {
            string pn = "";

            DataTable dt = new DataTable();
            string cmd = "SELECT phoneNumber FROM Person_Info a INNER JOIN Employee_Info b ON a.person_id = b.person_id WHERE b.employee_id = '" + eid + "'";

            LS_APIs.DAL.ModularDAL dal = new LS_APIs.DAL.ModularDAL();
            dt = dal.Select(cmd);

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    pn = row[column].ToString();
                }
            }

            return pn;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sends the employee a text notification about their shift. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="pn">   phone number of employee. </param>
        ///-------------------------------------------------------------------------------------------------

        static void SendSMS(string pn)
        {
            //Console.WriteLine(pn);

            // Your Account SID from twilio.com/console
            var accountSid = "AC23ba0e3fdebe48737465b9b747abed57";
            // Your Auth Token from twilio.com/console
            var authToken = "27d8e55b5e12e92dfabf8e07533f5d85";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber(pn),
                from: new PhoneNumber("+12268940693"),
                body: " Next Shift : " + DateTime.Now.AddDays(1).ToString());
        }

        public void SendShiftRequestSMS(string msg)
        {
            // Your Account SID from twilio.com/console
            var accountSid = "AC23ba0e3fdebe48737465b9b747abed57";
            // Your Auth Token from twilio.com/console
            var authToken = "27d8e55b5e12e92dfabf8e07533f5d85";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber("5195312937"),
                from: new PhoneNumber("+12268940693"),
                body: msg);
        }
    }
}
