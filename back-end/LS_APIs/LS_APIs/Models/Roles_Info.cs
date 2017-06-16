///-------------------------------------------------------------------------------------------------
// file:	Models\Roles_Info.cs
//
// summary:	Implements the roles information class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace LS_APIs.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Information about the roles. </summary>
    ///
    /// <remarks>   Wesley, 2017-04-17. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [DataContract]
    public class Roles_Info
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Wesley, 2017-04-17. </remarks>
        ///
        /// <param name="iEmpID">       Identifier for the emp. </param>
        /// <param name="iUsername">    Zero-based index of the username. </param>
        /// <param name="iPassword">    Zero-based index of the password. </param>
        /// <param name="iRole">        Zero-based index of the role. </param>
        ///-------------------------------------------------------------------------------------------------

        public Roles_Info(int iEmpID, string iUsername, string iPassword, string iRole)
        {
            employee_ID = iEmpID;
            userName = iUsername;
            password = iPassword;
            role = iRole;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the employee. </summary>
        ///
        /// <value> The identifier of the employee. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public int employee_ID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the user. </summary>
        ///
        /// <value> The name of the user. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string userName { get; set; } // Needs to be limits to max 20 chars 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the password. </summary>
        ///
        /// <value> The password. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string password { get; set; } // Needs to be limits to max 20 chars 

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the role. </summary>
        ///
        /// <value> The role. </value>
        ///-------------------------------------------------------------------------------------------------

        [DataMember]
        public string role { get; set; } // Needs to be limits to max 20 chars 
    }
}