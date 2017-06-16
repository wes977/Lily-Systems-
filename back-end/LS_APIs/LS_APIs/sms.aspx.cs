using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using LS_APIs.Controllers;
using LS_APIs.DAL;

namespace LS_APIs
{
    public partial class sms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the from value
            string From = Request["From"];
            //get the to value
            string To = Request["To"];
            //get the body value
            string Body = Request["Body"];

            Char delimiter = '@';
            String[] substrings = Body.Split(delimiter);
            string status = substrings[0];
            string empid = substrings[1];
            string strid = substrings[2];

            if (Body == "text")
            {
                // Your Account SID from twilio.com/console
                var accountSid = "AC23ba0e3fdebe48737465b9b747abed57";
                // Your Auth Token from twilio.com/console
                var authToken = "27d8e55b5e12e92dfabf8e07533f5d85";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    to: new PhoneNumber("5195312937"),
                    from: new PhoneNumber("+12268940693"),
                    body: "Hello");
            }

            if(status.ToLower().Trim() == "no")
            {
                Logic mdal = new Logic();
                mdal.Messenger(66, Convert.ToInt32(empid), "YOU SUCK", "DENIED!", DateTime.Now);
            }

            if(status.ToLower().Trim() == "yes")
            {
                Logic mdal = new Logic();
                mdal.Messenger(66, Convert.ToInt32(empid), "YOU ROCK", "APPROVED!", DateTime.Now);
                mdal.uShift(strid, "", "", empid, "");
                var message = MessageResource.Create(
                    to: new PhoneNumber("5195312937"),
                    from: new PhoneNumber("+12268940693"),
                    body: "The Shift ID " +strid + " has been taken by employee with ID" + empid);
            }
        }
    }
}