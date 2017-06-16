/*
 File Name      :   Credentials.cs
 Date           :   February 10, 2017
 Description    :   The credential class is responsible for dealing with the credentials of the users.. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LS_APIs.ScheduleBuilder
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   This is the Credentials class containing the credentials of users. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Credentials
    {
        /// <summary>   Name of the user. </summary>
        string userName;
        /// <summary>   The password. </summary>
        string password;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   This is the constructor for the class. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public Credentials()
        {
            userName = "";
            password = "";
        }
    }
}