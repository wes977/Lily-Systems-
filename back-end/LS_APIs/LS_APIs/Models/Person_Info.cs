///-------------------------------------------------------------------------------------------------
// file:	models\person_info.cs
//
// summary:	Implements the person information class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Information about the person. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Person_Info
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="ipersonID">    Identifier for the iperson. </param>
        /// <param name="ifName">       Name of if. </param>
        /// <param name="ilName">       Name of the il. </param>
        /// <param name="iphoneNum">    The iPhone number. </param>
        /// <param name="iemail">       The iemail. </param>
        /// <param name="address">      The address. </param>
        /// <param name="postal">       The postal. </param>
        /// <param name="icountry">     The icountry. </param>
        /// <param name="icity">        The icity. </param>
        /// <param name="socNum">       The soc number. </param>
        ///-------------------------------------------------------------------------------------------------

        public Person_Info(int ipersonID,string ifName , string ilName, string iphoneNum, string iemail,string address, string postal, string icountry,string icity,string socNum)
        {
            person_id = ipersonID;
            fName = ifName;
            lName = ilName;
            phoneNum = iphoneNum;
            email = iemail;
            personAddress = address;
            postalCode = postal;
            country = icountry;
            city = icity;
            socialNumber = socNum;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public Person_Info()
        {
            fName = "";
            lName = "";
            person_id = -1;
            phoneNum = "";
            email = "";

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the person. </summary>
        ///
        /// <value> The identifier of the person. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int person_id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The f name. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string fName { get; set; } // Needs to be limits to max 20 chars 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The l name. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string lName { get; set; } // 20

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the phone number. </summary>
        ///
        /// <value> The phone number. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string phoneNum { get; set; } // 15

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the email. </summary>
        ///
        /// <value> The email. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string email { get; set; } // 320

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the person address. </summary>
        ///
        /// <value> The person address. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string personAddress { get; set; } // 320

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the postal code. </summary>
        ///
        /// <value> The postal code. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string postalCode { get; set; } // 320

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the country. </summary>
        ///
        /// <value> The country. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string country { get; set; } // 320

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the city. </summary>
        ///
        /// <value> The city. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string city { get; set; } // 320

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the social number. </summary>
        ///
        /// <value> The social number. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string socialNumber { get; set; } // 320
    }
}